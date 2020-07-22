//13.08.08 initialVer张家Read SendMessage to UnityWebPlayer
//13.08.09 志鹏说的三个方法1.切换视角 2.传入坦克名字 3.控制坦克移动（未完成）

#region NameSpace
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using Test_InteractiveWebPlayer.RtiPart;
using System.Collections;
#endregion

namespace Test_InteractiveWebPlayer
{
    [ComVisible(true)]//设置类对Com可见
    public partial class Form1 : Form
    {
        public delegate void ReadMessageHandler(string msg);
        public event ReadMessageHandler ReadMsgEvent;
        //public delegate void SaveSceneHandle();
        //public event SaveSceneHandle SSEvent;

        private string pathSceneData;
        System.Windows.Forms.Timer time1;
        public Form1()
        {
            time1 = new System.Windows.Forms.Timer();
            time1.Interval = 100;
            time1.Tick += new EventHandler(time1_Tick);
            time1.Start();
            uavSendAndReceive = new UavSendAndReceive();
            InitializeComponent();
            uavSendAndReceive.OnNotifyMessage += new NotifyMessage(uavSendAndReceive_OnNotifyMessage);
            webBrowser1.Url = new Uri(Application.StartupPath + "\\data\\VirtualProtoWebPlayer.html");
            pathSceneData = Application.StartupPath + "\\UserData\\SceneData";
            webBrowser1.ObjectForScripting = this;
            iniRouteArrFromData();
        }

        void time1_Tick(object sender, EventArgs e)
        {
            int command;
            lock (CommonData.RtiReceiveData)
            {
                command = CommonData.RtiReceiveData.GetData();
            }
            uavSendAndReceive_OnNotifyMessage(command);
        }

        void uavSendAndReceive_OnNotifyMessage(int command)
        {

            switch (command)
            {
                case 8:
                    //Thread t0 = new Thread(new ThreadStart(SendArryTouUnity));
                    //t0.Start();
                    SendArryTouUnity();
                    break;//初始化
                case 3:
                    //Thread t1 = new Thread(new ThreadStart(TankMoveStart));
                    //t1.Start();
                    TankMoveStart();
                    break;//开始
                case 2:
                    Thread t2 = new Thread(new ThreadStart(TankPause));
                    TankPause();
                    break;//暂停
                case 7:
                    Thread t3 = new Thread(new ThreadStart(TankContinue));
                    TankContinue();
                    break;//继续
                case 14:
                    //Thread t4 = new Thread(new ThreadStart(SendArryTouUnity));

                    //ToggleCamView(1);
                    break;//第一人称视角
                case 15:
                    Thread t5 = new Thread(new ThreadStart(SendArryTouUnity));
                    ToggleCamView(0);
                    break;//第三人称视角
            }
        }

        public void SendMessage(Object[] Objects)
        {
            webBrowser1.Document.InvokeScript("SendMessage", Objects);
        }

        public void ReadMessages(string Message)
        {
            ReadMsgEvent(Message);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 选择场景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessage(new object[] { "SceneDataController", "ChooseScene", "" });
        }

        private void 改变天气ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessage(new object[] { "UI Root (2D)", "ChangeSkybox", "" });
        }

        private void 我方坦克ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessage(new object[] { "UI Root (2D)", "CreatTank0", "" });
        }

        private void palmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessage(new object[] { "UI Root (2D)", "CreatTree0", "" });
        }

        private void 敌方坦克ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessage(new object[] { "UI Root (2D)", "CreatEnemyTank0", "" });
        }

        #region 测试Unity发送消息保存本地 （未完成撒）
        public void 保存场景ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void FirstScene1Tank()
        {
            SendMessage(new object[] { "SceneDataController", "SaveTankWPData", "" });
            ReadMsgEvent += CreatScene1TankDataFile;
        }

        void FirstScene1EnemyTank()
        {
            SendMessage(new object[] { "SceneDataController", "SaveEnemyTankWPData", "" });
            ReadMsgEvent += CreatScene1EnemyTankDataFile;
        }

        void FirstScene1Tree()
        {
            SendMessage(new object[] { "SceneDataController", "SaveTreeWPData", "" });
            ReadMsgEvent += CreatScene1TreeDataFile;
        }

        #region SecondStep
        void CreatScene1TankDataFile(string str)
        {
            FileToolkitListener.CreatFile(pathSceneData + "\\Scene1", "TankData.txt", str, true);
        }
        void CreatScene1EnemyTankDataFile(string str)
        {
            FileToolkitListener.CreatFile(pathSceneData + "\\Scene1", "EnemyTankData.txt", str, true);
        }
        void CreatScene1TreeDataFile(string str)
        {
            FileToolkitListener.CreatFile(pathSceneData + "\\Scene1", "TreeData.txt", str, true);
        }
        #endregion
        #endregion

        private void 关于德馨同创ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strCom = "公司名称：德馨同创\n2013年8月16日";
            MessageBox.Show(strCom);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region 调用的方法13.08.09写的两个撒
        /// <summary>
        /// 切换相机视角
        /// </summary>
        /// <param name="isThirdView">bool第三人称视角还是主视角撒？0 for false;1 for true</param>
        void ToggleCamView(int isThirdView)
        {
            SendMessage(new object[] { "CameraController", "ToggleCamView", isThirdView });
            //ReadMsgEvent += ShowMessage;
        }

        /// <summary>
        /// 传入坦克名称
        /// </summary>
        /// <param name="tankName">坦克的名称撒！</param>
        void SetTankListName(string tankName)
        {
            SendMessage(new object[] { "UI Root (2D)", "SetTankListName", tankName });
        }

        private ArrayList tArry;
        void iniRouteArrFromData()
        {
            tArry = FileToolkitListener.LoadFile(Application.StartupPath + "\\UserData\\_TestRoute", "TestTestPath.txt");
        }

        void SendArryTouUnity()
        {
            for (int i = 0; i < tArry.Count; i++)
            {
                SendMessage(new object[] { "_Test_CtrlTank", "ReadRouteArrFromWinform", tArry[i] });
            }
        }

        void TankMoveStart()
        {
            SendMessage(new object[] { "_Test_CtrlTank", "TankMoveStart", "" });
        }

        void TankPause()
        {
            SendMessage(new object[] { "_Test_CtrlTank", "TankPause", "" });
        }

        void TankContinue()
        {
            SendMessage(new object[] { "_Test_CtrlTank", "TankContinue", "" });
        }
        #endregion


        UavSendAndReceive uavSendAndReceive;
        Thread monitorThread;
        private void 加入RtiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string fedFilePath = @"E:\juRti\certi\bin\xnyj.fed";//rtig所在的电脑的fed文件路径，且不能包含有中文
            uavSendAndReceive.InitFederation(true, true, 1, 0.01);
            uavSendAndReceive.JoinMyFederate("虚拟样机", "张家", fedFilePath);
            monitorThread = new Thread(delegate() { MyOwnTickThread(); });
            monitorThread.Start();
        }

        /// <summary>
        /// 自己的Tick进程
        /// </summary>
        public void MyOwnTickThread()
        {
            while (true)
            {
                uavSendAndReceive.uav_thread();
            }
        }

        private void 发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uavSendAndReceive.SendStkCommand();
        }

        private void 创建任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendArryTouUnity();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void 坦克移动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TankMoveStart();
        }

        private void 暂停移动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TankPause();
        }

        private void 继续移动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TankContinue();
        }

        private void testToggleCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleCamView(1);
        }

        void ShowMessage(string str)
        {
            //textBox1.Text = str;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 第三人称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleCamView(0);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
