using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hla.rti.jlc;
using hla.rti;

namespace Test_InteractiveWebPlayer.RtiPart
{
    public delegate void MyDiscoverObjectInstanceDelegate(int theObject, int theObjectClass, string objectName);
    public delegate void MyReflectAttributeValuesDelegate(int theObject, ReflectedAttributes theAttributes, byte[] userSuppliedTag);
    public delegate void MyRemoveObjectInstanceDelegate(int theObject, byte[] userSupplied);
    public delegate void MyReceiveInteractionDelegate(int theInteractionClass, ReceivedInteraction rei, byte[] bytess);

    public delegate void MyGetTimeConstrainedEnabledDelegate(LogicalTime lt);
    public delegate void MyGetTimeRegulationEnabledDelegate(LogicalTime lt);

    public class MyFederateAmbassador : NullFederateAmbassador
    {
        public event MyGetTimeConstrainedEnabledDelegate onMyGetTimeConstrainedEnabled;
        public void AlreadyGetTimeConstrainedEnabled(LogicalTime lt)
        {
            if (onMyGetTimeConstrainedEnabled != null)
            {
                onMyGetTimeConstrainedEnabled(lt);
            }
        }

        public event MyGetTimeRegulationEnabledDelegate OnMyGetTimeRegulationEnabled;
        public void AlreadyGetTimeRegulationEnabled(LogicalTime lt)
        {
            if (OnMyGetTimeRegulationEnabled != null)
            {
                OnMyGetTimeRegulationEnabled(lt);
            }
        }


        /// <summary>
        /// 发现对象实例时发生
        /// </summary>
        public event MyDiscoverObjectInstanceDelegate OnMyDiscoverObjectInstance;
        public void AlreadyDiscoverObjectInstance(int i1, int i2, string str)
        {
            if (OnMyDiscoverObjectInstance != null)
            {
                OnMyDiscoverObjectInstance(i1, i2, str);
            }
        }

        /// <summary>
        /// 对象实例属性更新时发生
        /// </summary>
        public event MyReflectAttributeValuesDelegate OnMyReflectAttributeValues;
        public void AlreadyReflectAttributeValues(int inde, ReflectedAttributes myra, byte[] barrss)
        {
            if (OnMyReflectAttributeValues != null)
            {
                OnMyReflectAttributeValues(inde, myra, barrss);
            }
        }

        /// <summary>
        /// 发现对象实例被Delete时发生
        /// </summary>
        public event MyRemoveObjectInstanceDelegate OnMyRemoveObjectInstance;
        public void AlreadyRemoveObjectInstance(int theObject, byte[] userSupplied)
        {
            if (OnMyRemoveObjectInstance != null)
            {
                OnMyRemoveObjectInstance(theObject, userSupplied);
            }
        }

        /// <summary>
        /// 接收到交互类时发生
        /// </summary>
        public event MyReceiveInteractionDelegate OnMyReceiveInteraction;
        public void AlreadyReceiveInteraction(int inde, ReceivedInteraction reit, byte[] bytes)
        {
            if (OnMyReceiveInteraction != null)
            {
                OnMyReceiveInteraction(inde, reit, bytes);
            }
        }

        public override void receiveInteraction(int theInteractionClass, ReceivedInteraction ri, byte[] barr)
        {
            AlreadyReceiveInteraction(theInteractionClass, ri, barr);
        }

        public override void reflectAttributeValues(int theObject, ReflectedAttributes theAttributes, byte[] userSuppliedTag)
        {
            AlreadyReflectAttributeValues(theObject, theAttributes, userSuppliedTag);
        }

        public override void discoverObjectInstance(int theObject, int theObjectClass, string objectName)
        {
            AlreadyDiscoverObjectInstance(theObject, theObjectClass, objectName);
        }

        public override void removeObjectInstance(int theObject, byte[] userSupplied)
        {
            AlreadyRemoveObjectInstance(theObject, userSupplied);
        }


        public override void timeAdvanceGrant(LogicalTime lt)
        {

        }

        public override void timeConstrainedEnabled(LogicalTime lt)
        {
            AlreadyGetTimeConstrainedEnabled(lt);
        }

        public override void timeRegulationEnabled(LogicalTime lt)
        {
            AlreadyGetTimeRegulationEnabled(lt);
        }
    }
}
