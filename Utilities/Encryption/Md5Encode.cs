using System;
using System.Security.Cryptography;
using System.Text;

namespace Utilities.Encryption
{
    public class Md5Encode
    {
        public static string Encode(string plainText, bool toLower)
        {
            string md5Ext = "basic#Ext@";
            byte[] result = Encoding.Default.GetBytes(plainText + md5Ext);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string md5Fin = BitConverter.ToString(output).Replace("-", "");
            if (toLower) return md5Fin.ToLower();
            return md5Fin;
        }

        public static string Encode(string plainText, bool toLower, string md5Ext)
        {
            byte[] result = Encoding.Default.GetBytes(plainText + md5Ext);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string md5Fin = BitConverter.ToString(output).Replace("-", "");
            if (toLower) return md5Fin.ToLower();
            return md5Fin;
        }

        public static string Utf8Encode(string plainText, bool toLower, string md5Ext)
        {
            byte[] result = Encoding.UTF8.GetBytes(plainText + md5Ext);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string md5Fin = BitConverter.ToString(output).Replace("-", "");
            if (toLower) return md5Fin.ToLower();
            return md5Fin;
        }

        public static string GetWebMd5(string str)
        {
            return GetWebMd5(str, Encoding.UTF8);
        }

        public static string GetWebMd5(string str, Encoding encoding)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(encoding.GetBytes(str));
            StringBuilder reString = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                reString.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return reString.ToString();
        }
    }
}
