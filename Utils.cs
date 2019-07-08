using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redactor
{
    public static class Utils
    {
        public static byte[] StringtToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        public static String BinaryToString(byte[] data, Encoding encoder)
        {
            return encoder.GetString(data);
        }
    }
}
