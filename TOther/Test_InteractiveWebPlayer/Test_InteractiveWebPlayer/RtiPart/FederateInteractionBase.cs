using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hla.rti;
using System.Reflection;
using hla.rti.jlc;

namespace Test_InteractiveWebPlayer.RtiPart
{
    public class FederateInteractionBase : FederateBase
    {
        protected RTIambassador rtia;
        protected PropertyInfo[] ps;
        public Dictionary<PropertyInfo, int> AttributeHandles = new Dictionary<PropertyInfo, int>();

        public int interactionClassHandle;
        //public int theObjectHandle;

        public AttributeHandleSet attributes;

        public FederateInteractionBase(RTIambassador rtia)
        {
            this.rtia = rtia;
            interactionClassHandle = rtia.getInteractionClassHandle(this.GetType().Name);
            ps = this.GetType().GetProperties();
            InitAttributeHandles();
        }



        protected void InitAttributeHandles()
        {
            attributes = RtiFactoryFactory.getRtiFactory().createAttributeHandleSet();
            foreach (var p in ps)
            {
                int Handle = rtia.getParameterHandle(p.Name, interactionClassHandle);
                AttributeHandles.Add(p, Handle);
                attributes.add(Handle);
            }
        }

        public void AddElement(SuppliedParameters parameters)
        {
            foreach (var p in ps)
            {
                int handle;
                if (AttributeHandles.TryGetValue(p, out handle))
                    parameters.add(handle, encodeValue(p));
            }
        }

        public void GetElement(SuppliedParameters parameters)
        {
            for (int i = 0; i < parameters.size(); i++)
            {
                PropertyInfo r = AttributeHandles.FirstOrDefault(p => p.Value == parameters.getHandle(i)).Key;
                if (r != null)
                {
                    r.SetValue(this, decodeValue(r, parameters.getValue(i)), null);
                }
            }
        }

        public void Send(string tag)
        {
            byte[] tags = EncodingHelpers.encodeString(tag);
            SuppliedParameters parameters = RtiFactoryFactory.getRtiFactory().createSuppliedParameters();
            AddElement(parameters);
            rtia.sendInteraction(interactionClassHandle, parameters, tags);
        }

        public void Send(string tag, LogicalTime lt)
        {
            byte[] tags = EncodingHelpers.encodeString(tag);
            SuppliedParameters parameters = RtiFactoryFactory.getRtiFactory().createSuppliedParameters();
            AddElement(parameters);
            rtia.sendInteraction(interactionClassHandle, parameters, tags, lt);
        }
    }
}
