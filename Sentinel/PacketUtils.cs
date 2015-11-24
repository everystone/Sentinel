using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentinel {
    class PacketUtils {
        public enum ValueType {
            Boolean,
            Int16,
            UInt16,
            Int32,
            UInt32,
            String,
            Float,
            Double
        }

        public static String isObjectOfType(byte[] bytes, ValueType type) {
            var res = "";
            try {
                switch (type) {
                    case ValueType.Boolean:
                        res = String.Format("Boolean: {0}", BitConverter.ToBoolean(bytes, 0).ToString());
                        break;
                    case ValueType.Int16:
                        res = String.Format("Int16: {0}", BitConverter.ToInt16(bytes, 0).ToString());
                        break;
                    case ValueType.Int32:
                        res = String.Format("Int32: {0}", BitConverter.ToInt32(bytes, 0).ToString());
                        break;
                    case ValueType.UInt16:
                        res = String.Format("UInt16: {0}", BitConverter.ToUInt16(bytes, 0).ToString());
                        break;
                    case ValueType.UInt32:
                        res = String.Format("UInt32: {0}", BitConverter.ToUInt32(bytes, 0).ToString());
                        break;
                    case ValueType.String:
                        res = String.Format("String: {0}", BitConverter.ToString(bytes, 0).ToString());
                        break;
                    case ValueType.Float:
                        res = String.Format("Float: {0}", BitConverter.ToSingle(bytes, 0).ToString());
                        break;
                    case ValueType.Double:
                        res = String.Format("Double: {0}", BitConverter.ToDouble(bytes, 0).ToString());
                        break;
                }
            }
            catch (Exception e) {
                Console.WriteLine("ex decoding: " + e.Message);
                return "";
            }
            return res;
        }
    }
}
