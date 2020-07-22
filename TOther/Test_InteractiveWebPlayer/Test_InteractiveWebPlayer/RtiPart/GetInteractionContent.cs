using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hla.rti;
using System.Reflection;
using hla.rti.jlc;

namespace Test_InteractiveWebPlayer.RtiPart
{
    /// <summary>
    /// 接收到的交互类byte数组转换为类具体内容
    /// </summary>
    public class GetInteractionContent
    {
        public static void GetContent(object tim, ReceivedInteraction rein)
        {
            PropertyInfo[] pis = tim.GetType().GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                pis[i].SetValue(tim, UseEncodingHelpersToGetValue(pis[i], rein, i), null);
            }
        }

        private static object UseEncodingHelpersToGetValue(PropertyInfo propertyInfo, ReceivedInteraction rein, int index)
        {
            object temporaryVariable;
            string propertytype = propertyInfo.PropertyType.Name;
            switch (propertytype)
            {
                case "Boolean":
                    temporaryVariable = EncodingHelpers.decodeBoolean(rein.getValue(index));
                    break;
                case "Byte":
                    temporaryVariable = EncodingHelpers.decodeByte(rein.getValue(index));
                    break;
                case "Char":
                    temporaryVariable = EncodingHelpers.decodeChar(rein.getValue(index));
                    break;
                case "Double":
                    temporaryVariable = EncodingHelpers.decodeDouble(rein.getValue(index));
                    break;
                case "Single":
                    temporaryVariable = EncodingHelpers.decodeFloat(rein.getValue(index));
                    break;
                case "Int32":
                    temporaryVariable = EncodingHelpers.decodeInt(rein.getValue(index));
                    break;
                case "Int64":
                    temporaryVariable = EncodingHelpers.decodeLong(rein.getValue(index));
                    break;
                case "Int16":
                    temporaryVariable = EncodingHelpers.decodeShort(rein.getValue(index));
                    break;
                case "String":
                    temporaryVariable = EncodingHelpers.decodeString(rein.getValue(index));
                    break;
                default:
                    temporaryVariable = null;
                    break;
            }
            return temporaryVariable;
        }
    }
}
