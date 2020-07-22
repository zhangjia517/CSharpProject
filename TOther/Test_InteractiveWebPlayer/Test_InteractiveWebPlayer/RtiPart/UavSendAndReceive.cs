using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using certi.rti.impl;
using hla.rti;
using hla.rti.jlc;
using java.io;
using System.Threading;

namespace Test_InteractiveWebPlayer.RtiPart
{
    public delegate void ShowTankLocation(float x, float y);
    public delegate void ShowLocalTime(double tm);
    public  delegate void NotifyMessage(int command);

    public class UavSendAndReceive
    {
        string m_szFederationName;//联邦名
        string m_szFederateName;//联邦成员名
        string m_szFedFileName;//config目录下fed文件名
        double SimTimeStep;	//仿真步长，只需设置一次
        double Lookahead;  //前瞻量
        bool m_bRegulation;//本成员控制联邦时间，标志为真
        bool m_bConstrained;//本成员被联邦时间约束，标志为真
        LogicalTimeInterval m_tLookahead;//联邦成员时间前瞻量
        LogicalTime m_tTimeStamp = new CertiLogicalTime(0.0);//联邦成员时戳
        //RTIfedTime m_tGrantTime;//联邦时间（RTI服务器时间）
        LogicalTime m_tGrantTime = new CertiLogicalTime(0.0);//联邦时间（RTI服务器时间）
        //LogicalTime m_tGrantTime;//联邦时间（RTI服务器时间）
        bool m_bTimeAdvGrant;//成员时间推进允许标志
        SimulationCommandEnum eControlState;//总控送来的状态控制命令;
        bool bSimulationThreadFlag = true;	//用户可以用自己的变量替代


        public event ShowTankLocation OnShowTankLocation;
        public void IsShowTankLocation(float x1, float y1)
        {
            if (OnShowTankLocation != null)
            {
                OnShowTankLocation(x1, y1);
            }
        }

        public event ShowLocalTime OnShowLocalTime;
        public void IsShowLocalTime(double tm1)
        {
            if (OnShowLocalTime != null)
            {
                OnShowLocalTime(tm1);
            }
        }


        enum SimState
        {
            /// <summary>
            /// 空闲状态
            /// </summary>
            SIM_IDLE = 1,

            /// <summary>
            /// 设置就绪状态
            /// </summary>
            SIM_READY = 2,

            /// <summary>
            /// 运行状态
            /// </summary>
            SIM_RUN = 3,

            /// <summary>
            /// 暂停状态
            /// </summary>
            SIM_PAUSE = 4,

            /// <summary>
            /// 退出状态
            /// </summary>
            SIM_EXIT = 5
        };
        SimState CurRunState;
        enum SimulationCommandEnum
        {
            /// <summary>
            /// 
            /// </summary>
            UNKNOWN_SIMULATION = 0,

            /// <summary>
            /// 想定设置
            /// </summary>
            INIT_SCENARIO = 1,

            /// <summary>
            /// 开始命令
            /// </summary>
            START_SIMULATION = 2,

            /// <summary>
            /// 退出
            /// </summary>
            STOP_SIMULATION = 3,

            /// <summary>
            /// 暂停
            /// </summary>
            PAUSE_SIMULATION = 4,

            /// <summary>
            /// 成员点名
            /// </summary>
            CALL_FEDERATE = 5
        };

        #region 所有对象类和交互类句柄的声明

        //对象类
        int classHandle_AewRadar;
        //交互类
        int classHandle_CheckLeagueName;
        int classHandle_TankInteractModel;
        int classHandle_StkControlCommand;

        #endregion


        public RTIambassador rtia;
        FederateAmbassador mya;

        /// <summary>
        /// 加入到联邦
        /// </summary>
        public void JoinMyFederate(string FederationName, string FederateName, string fedFilePath)
        {
            m_szFederationName = FederationName;
            m_szFederateName = FederateName;
            m_szFedFileName = "xnyj.fed";
            CurRunState = SimState.SIM_IDLE;
            try
            {
                RtiFactory factory = RtiFactoryFactory.getRtiFactory();
                rtia = factory.createRtiAmbassador();
                File fom = new File(fedFilePath);
                rtia.createFederationExecution(FederationName, fom.toURI().toURL());
            }
            catch (Exception ex)
            {

            }

            try
            {
                mya = new MyFederateAmbassador();
                ((MyFederateAmbassador)mya).onMyGetTimeConstrainedEnabled += new MyGetTimeConstrainedEnabledDelegate(UavSendAndReceive_onMyGetTimeConstrainedEnabled);
                ((MyFederateAmbassador)mya).OnMyGetTimeRegulationEnabled += new MyGetTimeRegulationEnabledDelegate(UavSendAndReceive_OnMyGetTimeRegulationEnabled);

                ((MyFederateAmbassador)mya).OnMyDiscoverObjectInstance += new MyDiscoverObjectInstanceDelegate(UavSendAndReceive_OnMyDiscoverObjectInstance);
                ((MyFederateAmbassador)mya).OnMyReflectAttributeValues += new MyReflectAttributeValuesDelegate(UavSendAndReceive_OnMyReflectAttributeValues);
                ((MyFederateAmbassador)mya).OnMyReceiveInteraction += new MyReceiveInteractionDelegate(UavSendAndReceive_OnMyReceiveInteraction);
                rtia.joinFederationExecution(FederateName, FederationName, mya);
                rtia.enableAttributeRelevanceAdvisorySwitch();
                GetInteractionHandle(rtia);
                GetObjectHandle(rtia);
                GetAttrHandleSet();
                InteractionPublishAndSubscribe(rtia);
                ObjectPublishAndSubscribe(rtia);
                InitializeTimeManagement();
                EnableAsynchronousDelivery();
            }
            catch (Exception ex)
            {

            }
        }

        void UavSendAndReceive_OnMyGetTimeRegulationEnabled(LogicalTime lt)
        {
            m_bTimeAdvGrant = true;
        }

        void UavSendAndReceive_onMyGetTimeConstrainedEnabled(LogicalTime lt)
        {
            m_bTimeAdvGrant = true;
        }

        private void EnableAsynchronousDelivery()
        {
            try
            {
                rtia.enableAsynchronousDelivery();
            }
            catch (Exception ex)
            {

            }

        }

        void UavSendAndReceive_OnMyDiscoverObjectInstance(int int1, int int2, string mystr)
        {

        }

        void UavSendAndReceive_OnMyReflectAttributeValues(int i, ReflectedAttributes ra, byte[] barr)
        {

        }

        void UavSendAndReceive_OnMyReceiveInteraction(int index, ReceivedInteraction rei, byte[] bytess)
        {

            string myInterClassName = rtia.getInteractionClassName(index);

            switch (myInterClassName)
            {
                case "CheckLeagueName":
                    GetMyReceive_CheckLeagueName_Data(index, rei, bytess);
                    break;
                case "TankInteractModel":
                    GetMyReceive_TankInteractModel_Data(index, rei, bytess);
                    break;
                case "StkControlCommand":
                    GetMyReceive_StkControlCommand_Data(index, rei, bytess);
                    break;
                default:
                    break;
            }
        }
        public event NotifyMessage OnNotifyMessage;
        private void GetMyReceive_StkControlCommand_Data(int index, ReceivedInteraction rei, byte[] bytess)
        {
            StkControlCommand scc = new StkControlCommand(rtia);
            GetInteractionContent.GetContent(scc, rei);
            lock (CommonData.RtiReceiveData)
            {
                CommonData.RtiReceiveData.PutData(scc.CommandId);
            }
            //Thread.Sleep(10);
            //lock (CommonData.RtiReceiveData)
            //{
            //    if (OnNotifyMessage != null)
            //    {
            //        OnNotifyMessage(CommonData.RtiReceiveData.GetData());
            //    }                
            //}            
        }

        public void SendStkCommand()
        {
            StkControlCommand scc = new StkControlCommand(rtia);
            scc.CommandId = 46;
            scc.Send("命令");
        }



        /// <summary>
        /// 时间管理初始化
        /// </summary>
        private void InitializeTimeManagement()
        {
            if (!m_bRegulation && !m_bConstrained)
            {
                return;
            }

            else if (m_bRegulation && !m_bConstrained)
            {
                WaitForEnableTimeRegulation();
            }

            else if (!m_bRegulation && m_bConstrained)
            {
                WaitForEnableTimeConstrained();
            }
            else
            {
                WaitForEnableTimeRegulation();
                WaitForEnableTimeConstrained();
            }
        }

        /// <summary>
        /// 声明时间推进策略：成员受联邦约束
        /// </summary>
        private void WaitForEnableTimeConstrained()
        {
            try
            {
                m_bTimeAdvGrant = false;
                rtia.enableTimeConstrained();
                while (!m_bTimeAdvGrant)
                {
                    ((CertiRtiAmbassador)rtia).tick(0.001, 0.01);
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 声明时间推进策略：成员控制联邦
        /// </summary>
        private void WaitForEnableTimeRegulation()
        {
            try
            {
                m_bTimeAdvGrant = false;
                rtia.enableTimeRegulation(m_tGrantTime, m_tLookahead);
                while (!m_bTimeAdvGrant)
                {
                    ((CertiRtiAmbassador)rtia).tick(0.001, 0.01);
                }
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 获得交互类句柄、参数句柄
        /// </summary>
        public void GetInteractionHandle(RTIambassador rtia)
        {
            classHandle_CheckLeagueName = rtia.getInteractionClassHandle("CheckLeagueName");
            classHandle_TankInteractModel = rtia.getInteractionClassHandle("TankInteractModel");
            classHandle_StkControlCommand = rtia.getInteractionClassHandle("StkControlCommand");
        }

        /// <summary>
        /// 获得对象类句柄、属性句柄
        /// </summary>
        /// <param name="rtia"></param>
        public void GetObjectHandle(RTIambassador rtia)
        {
            classHandle_AewRadar = rtia.getObjectClassHandle("AewRadar");
        }

        /// <summary>
        /// 获得对象类属性句柄集
        /// </summary>
        public void GetAttrHandleSet()
        {

        }

        /// <summary>
        /// 交互类公布与订购处理
        /// </summary>
        public void InteractionPublishAndSubscribe(RTIambassador rtia)
        {
            //公布交互
            rtia.publishInteractionClass(classHandle_CheckLeagueName);
            rtia.publishInteractionClass(classHandle_StkControlCommand);


            //订购交互
            rtia.subscribeInteractionClass(classHandle_CheckLeagueName);
            rtia.subscribeInteractionClass(classHandle_TankInteractModel);
            rtia.subscribeInteractionClass(classHandle_StkControlCommand);
        }

        /// <summary>
        /// 对象类公布与订购处理
        /// </summary>
        public void ObjectPublishAndSubscribe(RTIambassador rtia)
        {
            //公布对象及其属性
            //AewAircraft aewAircraft = new AewAircraft(rtia);
            //rtia.publishObjectClass(classHandle_AewAircraft, aewAircraft.attributeHandles);

            //PsyAircraft psyAircraft = new PsyAircraft(rtia);
            //rtia.publishObjectClass(classHandle_PsyAircraft, psyAircraft.attributeHandles);

            //订购对象及其属性
        }

        public void GetMyReceive_CheckLeagueName_Data(int ind, ReceivedInteraction rein, byte[] mybytes)
        {
            CheckLeagueName checkLeagueName = new CheckLeagueName(rtia);
            GetInteractionContent.GetContent(checkLeagueName, rein);

            if (checkLeagueName.MyFederationName == "我是总控")
            {
                eControlState = (SimulationCommandEnum)checkLeagueName.GrandControlCommandId;
                if (checkLeagueName.IsAllLeagueExit)
                {
                    System.Environment.Exit(0);
                }
                else if (checkLeagueName.GrandControlCommandId == (int)SimulationCommandEnum.CALL_FEDERATE)
                {
                    CheckLeagueName myName = new CheckLeagueName(rtia);
                    myName.MyFederationName = m_szFederateName;
                    myName.GrandControlCommandId = 0;
                    myName.IsAllLeagueExit = false;
                    myName.Send("我是坦克,我已经收到!");
                }
            }
        }

        private void GetMyReceive_TankInteractModel_Data(int ind, ReceivedInteraction rein, byte[] mybytes)
        {
            //TankInteractModel tim = new TankInteractModel(rtia);
            //GetInteractionContent.GetContent(tim, rein);
        }

        double startTime = 0.0;
        public void uav_thread()
        {
            //((CertiRtiAmbassador)rtia).tick();
            while (bSimulationThreadFlag)
            {
                ((CertiRtiAmbassador)rtia).tick();
                Thread.Sleep(1);

                if (CurRunState == SimState.SIM_IDLE)
                {
                    //空闲状态下，接收“成员点名”命令，之后保持当前状态
                    if (eControlState == SimulationCommandEnum.CALL_FEDERATE)
                    {
                        // 将控制信息清零
                        //SimControlResponse(eControlState);
                        eControlState = SimulationCommandEnum.UNKNOWN_SIMULATION;

                    }
                    //空闲状态下，处理“想定设置”命令，之后状态转移为 设置就绪状态
                    else if (eControlState == SimulationCommandEnum.INIT_SCENARIO)
                    {
                        //初始化本成员的所有模型对象和公布对象
                        //TODO:: CreateModel();	

                        //SimControlResponse(eControlState);
                        eControlState = SimulationCommandEnum.UNKNOWN_SIMULATION;
                        CurRunState = SimState.SIM_READY;
                    }
                }
                else if (CurRunState == SimState.SIM_READY)
                {
                    //设置就绪状态下，接收“退出”命令，之后状态转移为 退出状态
                    if (eControlState == SimulationCommandEnum.STOP_SIMULATION)
                    {
                        CurRunState = SimState.SIM_EXIT;

                    }
                    //设置就绪状态下，接收“开始”命令，之后状态转移为 运行状态
                    if ((eControlState == SimulationCommandEnum.START_SIMULATION))
                    {
                        // 将控制信息清零
                        //SimControlResponse(eControlState);
                        eControlState = SimulationCommandEnum.UNKNOWN_SIMULATION;

                        CurRunState = SimState.SIM_RUN;

                    }
                }
                else if (CurRunState == SimState.SIM_RUN)
                {
                    //运行状态下，每步进行模型步进处理
                    // 对象属性按步长更新
                    // 处理各种交互


                    //pSim->ProcessCombatAircraftObject();

                    //TRACE("一次处理 \n");
                    //运行状态下，接收“退出”命令，之后状态转移为 退出状态
                    if (eControlState == SimulationCommandEnum.STOP_SIMULATION)
                    {
                        CurRunState = SimState.SIM_EXIT;

                    }
                    //运行状态下，接收“暂停”命令，之后状态转移为 暂停状态
                    if (eControlState == SimulationCommandEnum.PAUSE_SIMULATION)
                    {
                        //m_bTimeAdvGrant = false;
                        //SimControlResponse(eControlState);
                        eControlState = SimulationCommandEnum.UNKNOWN_SIMULATION;
                        //将控制信息清零
                        CurRunState = SimState.SIM_PAUSE;

                    }
                }//
                else if (CurRunState == SimState.SIM_PAUSE)
                {
                    //暂停状态下，接收“开始”命令，之后状态转移为 继续运行状态
                    if ((eControlState == SimulationCommandEnum.START_SIMULATION))
                    {
                        //将控制信息清零
                        //SimControlResponse(eControlState);
                        //m_bTimeAdvGrant = true;
                        eControlState = SimulationCommandEnum.UNKNOWN_SIMULATION;
                        CurRunState = SimState.SIM_RUN;

                    }
                    //暂停状态下，接收“退出”命令，之后状态转移为 退出状态
                    if (eControlState == SimulationCommandEnum.STOP_SIMULATION)
                    {
                        CurRunState = SimState.SIM_EXIT;

                    }
                }//

                //如果是退出状态
                if (CurRunState == SimState.SIM_EXIT)
                {
                    //timeKillEvent(MT_ID);
                    //Sleep(1000);
                    // 对象重置到初始参数
                    //gSimTime = 0;
                    //删除各对象
                    UserPubObjectContainerClear();
                    bSimulationThreadFlag = false;

                }
                //如果是运行状态
                else if (CurRunState == SimState.SIM_RUN)
                {
                    //pSim->OnModelStep(gSimTime);
                    //ModelOneStep();	
                    //pFed->UserSubInterContainerClear();
                    rtia.tick();
                    Thread.Sleep(1);

                    if (!m_bRegulation && !m_bConstrained)
                    {
                        rtia.tick();
                        Thread.Sleep(1);
                    }
                    else
                    {
                        try
                        {
                            //((CertiRtiAmbassador)rtia).tick(1.0, 1.0);
                            //startTime += 1.11111;
                            //((CertiRtiAmbassador)rtia).timeAdvanceRequest(new CertiLogicalTime(startTime));
                            //var time = ((CertiRtiAmbassador)rtia).queryFederateTime();

                            m_tGrantTime = rtia.queryFederateTime();
                            double ss1 = Convert.ToDouble(m_tGrantTime.ToString());
                            double ss2 = Convert.ToDouble(SimTimeStep);
                            double ss = ss1 + ss2;
                            LogicalTime mm = new CertiLogicalTime(ss);
                            rtia.timeAdvanceRequest(mm);
                            IsShowLocalTime(ss);
                        }
                        catch (InvalidFederationTime ex)
                        {

                        }
                        catch (FederationTimeAlreadyPassed ex)
                        {

                        }
                        catch (TimeAdvanceAlreadyInProgress ex)
                        {

                        }
                        catch (EnableTimeConstrainedPending ex)
                        {

                        }
                        catch (EnableTimeRegulationPending ex)
                        {

                        }
                        catch (FederateNotExecutionMember ex)
                        {

                        }
                        catch (ConcurrentAccessAttempted ex)
                        {

                        }
                        catch (SaveInProgress ex)
                        {

                        }
                        catch (RestoreInProgress ex)
                        {

                        }
                        catch (RTIinternalError ex)
                        {

                        }
                    }

                }
            }
        }

        /// <summary>
        /// 所有公布对象移出容器、退出RTI、删除
        /// </summary>
        private void UserPubObjectContainerClear()
        {

        }

        /// <summary>
        /// 发送我公布的交互类
        /// </summary>
        public void SendMyPublishInteraction()
        {

        }

        //AewAircraft myAewAircraft2;
        //PsyAircraft myPsyAircraft2;
        /// <summary>
        /// 发送我公布的对象类
        /// </summary>
        public void SendMyPublishObject()
        {
            //注册
            //myObject_myAewAircraft2 = rtia.registerObjectInstance(classHandle_AewAircraft, "AewAirNo1");

            //属性更新
            //myAewAircraft2 = new AewAircraft(rtia);
            //myAewAircraft2.radarType = "超级旗舰机1";
            //myAewAircraft2.residenceCommandPostID = "No1";
            //myAewAircraft2.flightTime = 1.1111F;
            //myAewAircraft2.isHeadFlag = false;
            //myAewAircraft2.formationID = "111111";
            //myAewAircraft2.theObjectHandle = myObject_myAewAircraft2;
            //myAewAircraft2.UpdateAttributeValues("aaaaa");

            //注册
            //myObject_myPsyAircraft2 = rtia.registerObjectInstance(classHandle_PsyAircraft, "PsyAirNo2");

            //属性更新
            //myPsyAircraft2 = new PsyAircraft(rtia);
            //myPsyAircraft2.WeaponType = "心理战机";
            //myPsyAircraft2.IsFly = false;
            //myPsyAircraft2.MyNum = 1;
            //myPsyAircraft2.OilQuantity = 3.3333F;
            //myPsyAircraft2.theObjectHandle = myObject_myPsyAircraft2;
            //myPsyAircraft2.UpdateAttributeValues("ccccc");
        }

        public void ReflectOnce()
        {
            //myPsyAircraft2.WeaponType = "心理战机";
            //myPsyAircraft2.IsFly = true;
            //myPsyAircraft2.MyNum = 2;
            //myPsyAircraft2.OilQuantity = 4.4444F;
            //myPsyAircraft2.theObjectHandle = myObject_myPsyAircraft2;
            //myPsyAircraft2.UpdateAttributeValues("dddddd");
        }

        public void DeleteMyInstance()
        {
            byte[] aa = EncodingHelpers.encodeString("删除");
            //rtia.deleteObjectInstance(myObject_myPsyAircraft2, aa);
        }

        /// <summary>
        /// 初始化联邦
        /// </summary>
        /// <param name="Regulation">设为[true]时本成员控制联邦时间</param>
        /// <param name="Constrained">设为[true]时本成员被联邦时间约束</param>
        /// <param name="SimTimeStep">仿真步长,单位秒</param>
        /// <param name="Lookahead">联邦成员时间前瞻量（一般要小于本成员仿真步长），单位秒</param>
        internal void InitFederation(bool Regulation, bool Constrained, double simTimeStep, double lookahead)
        {
            m_bRegulation = Regulation;
            m_bConstrained = Constrained;
            SimTimeStep = simTimeStep;
            Lookahead = lookahead;
            m_tLookahead = new CertiLogicalTimeInterval(Lookahead);
        }
    }
}
