using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace Redactor
{
    public static class Utils
    {
        public static byte[] StringToByteArray(string str, Encoding encoding)
        {
            return PackFile(encoding.GetBytes(str));
        }

        public static String BinaryToString(byte[] data, Encoding encoder)
        {
            return encoder.GetString(UnPackFile(data));
        }


        private static byte[] PackFile(byte[] inputFileBytes)
        {

            using (Stream memOutput = new MemoryStream())
            using (ZipOutputStream zipOutput = new ZipOutputStream(memOutput))
            {
                zipOutput.SetLevel(9);

                ZipEntry entry = new ZipEntry("Name");
                entry.DateTime = DateTime.Now;
                zipOutput.PutNextEntry(entry);

                zipOutput.Write(inputFileBytes, 0, inputFileBytes.Length);
                zipOutput.Finish();

                byte[] newBytes = new byte[memOutput.Length];
                memOutput.Seek(0, SeekOrigin.Begin);
                memOutput.Read(newBytes, 0, newBytes.Length);

                zipOutput.Close();

                return newBytes;
            }
        }

        private static byte[] UnPackFile(byte[] inputFileBytes)
        {
            byte[] unPackedBytes = null;
            using (Stream memInput = new MemoryStream(inputFileBytes))
            using (ZipInputStream input = new ZipInputStream(memInput))
            {
                ZipEntry entry = input.GetNextEntry();

                unPackedBytes = new byte[entry.Size];
                int count = input.Read(unPackedBytes, 0, unPackedBytes.Length);
                if (count != entry.Size)
                {
                    throw new Exception("Invalid read: " + count);
                }
            }
            return unPackedBytes;
        }
    }
}
