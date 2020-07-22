using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hla.rti;
using System.Reflection;
using hla.rti.jlc;

namespace Test_InteractiveWebPlayer.RtiPart
{
    public class FederateBase
    {
        protected byte[] encodeValue(PropertyInfo p)
        {
            if (p.PropertyType == typeof(bool))
            {
                return EncodingHelpers.encodeBoolean(Convert.ToBoolean(p.GetValue(this, null)));
            }
            else if (p.PropertyType == typeof(byte))
            {
                return EncodingHelpers.encodeByte(Convert.ToInt32(p.GetValue(this, null)));
            }
            else if (p.PropertyType == typeof(char))
            {
                return EncodingHelpers.encodeChar(Convert.ToChar(p.GetValue(this, null)));
            }
            else if (p.PropertyType == typeof(double))
            {
                return EncodingHelpers.encodeDouble(Convert.ToDouble(p.GetValue(this, null)));
            }
            else if (p.PropertyType == typeof(float))
            {
                return EncodingHelpers.encodeFloat(Convert.ToSingle(p.GetValue(this, null)));
            }
            else if (p.PropertyType == typeof(int))
            {
                return EncodingHelpers.encodeInt(Convert.ToInt32(p.GetValue(this, null)));
            }
            else if (p.PropertyType == typeof(long))
            {
                return EncodingHelpers.encodeLong(Convert.ToInt64(p.GetValue(this, null)));
            }
            else if (p.PropertyType == typeof(short))
            {
                return EncodingHelpers.encodeShort(Convert.ToInt16(p.GetValue(this, null)));
            }
            else if (p.PropertyType == typeof(string))
            {
                return EncodingHelpers.encodeString(p.GetValue(this, null).ToString());
            }
            else
            {
                return null;
            }
        }

        protected object decodeValue(PropertyInfo p, byte[] data)
        {
            if (p.PropertyType == typeof(bool))
            {
                return EncodingHelpers.decodeBoolean(data);
            }
            else if (p.PropertyType == typeof(byte))
            {
                return EncodingHelpers.decodeByte(data);
            }
            else if (p.PropertyType == typeof(char))
            {
                return EncodingHelpers.decodeChar(data);
            }
            else if (p.PropertyType == typeof(double))
            {
                return EncodingHelpers.decodeDouble(data);
            }
            else if (p.PropertyType == typeof(float))
            {
                return EncodingHelpers.decodeFloat(data);
            }
            else if (p.PropertyType == typeof(int))
            {
                return EncodingHelpers.decodeInt(data);
            }
            else if (p.PropertyType == typeof(long))
            {
                return EncodingHelpers.decodeLong(data);
            }
            else if (p.PropertyType == typeof(short))
            {
                return EncodingHelpers.decodeShort(data);
            }
            else if (p.PropertyType == typeof(string))
            {
                return EncodingHelpers.decodeString(data);
            }
            else
            {
                return null;
            }
        }
    }
}
