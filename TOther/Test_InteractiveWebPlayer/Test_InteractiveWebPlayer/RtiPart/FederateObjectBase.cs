using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hla.rti;
using System.Reflection;
using hla.rti.jlc;

namespace Test_InteractiveWebPlayer.RtiPart
{
    public class FederateObjectBase : FederateBase
    {
        RTIambassador rtia;
        PropertyInfo[] ps;
        public Dictionary<PropertyInfo, int> AttributeHandles = new Dictionary<PropertyInfo, int>();

        public int objectClassHandle;
        public int theObjectHandle;

        public AttributeHandleSet attributeHandles;

        public FederateObjectBase(RTIambassador rtia)
        {
            this.rtia = rtia;
            objectClassHandle = rtia.getObjectClassHandle(this.GetType().Name);
            ps = this.GetType().GetProperties();
            InitAttributeHandles();
        }

        private void InitAttributeHandles()
        {
            attributeHandles = RtiFactoryFactory.getRtiFactory().createAttributeHandleSet();
            foreach (var p in ps)
            {
                int Handle = rtia.getAttributeHandle(p.Name, objectClassHandle);
                AttributeHandles.Add(p, Handle);
                attributeHandles.add(Handle);
            }
        }


        public void AddElement(SuppliedAttributes attributes)
        {
            foreach (var p in ps)
            {
                int handle;
                if (AttributeHandles.TryGetValue(p, out handle))
                    attributes.add(handle, encodeValue(p));
            }
        }

        public void GetElement(ReflectedAttributes theAttributes)
        {
            for (int i = 0; i < theAttributes.size(); i++)
            {
                PropertyInfo r = AttributeHandles.FirstOrDefault(p => p.Value == theAttributes.getAttributeHandle(i)).Key;
                if (r != null)
                {
                    r.SetValue(this, decodeValue(r, theAttributes.getValue(i)), null);
                }
            }
        }

        public void UpdateAttributeValues(string tag)
        {
            try
            {
                byte[] tags = EncodingHelpers.encodeString(tag);
                SuppliedAttributes updateAttributes = RtiFactoryFactory.getRtiFactory().createSuppliedAttributes();
                AddElement(updateAttributes);
                rtia.updateAttributeValues(theObjectHandle, updateAttributes, tags);
            }
            catch (Exception e) { }
        }
    }
}
