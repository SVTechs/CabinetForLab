using System;
using System.IO;
using System.Text;

namespace Utilities.FileHelper
{
    public class FileHelper
    {
        public static bool CheckFileContent(string file, string sig)
        {
            if (!File.Exists(file)) return false;
            FileStream fs = File.Open(file, FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);
            fs.Close();
            string fileContent = Encoding.UTF8.GetString(buffer);
            if (fileContent.Contains(sig)) return true;
            return false;
        }

        public static int WriteFile(string path, string content)
        {
            try
            {
                FileStream csStream = File.Open(path, FileMode.Create, FileAccess.Write);
                byte[] csBuffer = Encoding.UTF8.GetBytes(content);
                csStream.Write(csBuffer, 0, csBuffer.Length);
                csStream.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string GetMd5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed:" + ex.Message);
            }
        }
    }
}
