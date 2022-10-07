using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Utilities.DbHelper;

namespace Utilities.Data
{
    public class DataSetHelper
    {
        public static string EncodeDataSet(DataSet origin)
        {
            if (!SqlDataHelper.IsDataValid(origin)) return null;
            byte[] binData = GetBinaryFormatData(origin);
            byte[] compressedData = Compress(binData);
            return ByteToHexStr(compressedData);
        }

        public static DataSet DecodeDataSet(string hexData)
        {
            if (string.IsNullOrEmpty(hexData)) return null;
            byte[] binData = HexStrToByte(hexData);
            byte[] decData = Decompress(binData);
            return RetrieveDataSet(decData);
        }

        public static byte[] GetBinaryFormatData(DataSet dsOriginal)
        {
            byte[] binaryDataResult = null;
            MemoryStream memStream = new MemoryStream();

            //以二进制格式将对象或整个连接对象图形序列化和反序列化。
            IFormatter brFormatter = new BinaryFormatter();

            //dsOriginal.RemotingFormat 为远程处理期间使用的DataSet 获取或设置 SerializtionFormat        
            //SerializationFormat.Binary      将字符串比较方法设置为使用严格的二进制排序顺序
            dsOriginal.RemotingFormat = SerializationFormat.Binary;

            //把字符串以二进制放进memStream中
            brFormatter.Serialize(memStream, dsOriginal);
            //转为byte数组
            binaryDataResult = memStream.ToArray();

            memStream.Close();
            memStream.Dispose();
            return binaryDataResult;
        }

        public static DataSet RetrieveDataSet(byte[] binaryData)
        {
            MemoryStream memStream = new MemoryStream(binaryData, true);

            IFormatter brFormatter = new BinaryFormatter();
            return (DataSet)brFormatter.Deserialize(memStream);
        }

        private static byte[] HexStrToByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);
            return returnBytes;
        }

        private static string ByteToHexStr(byte []buffer)
        {
            StringBuilder strBuider = new StringBuilder();
            for (int index = 0; index < buffer.Length; index++)
            {
                strBuider.Append(((int)buffer[index]).ToString("X2"));
            }
            return strBuider.ToString();
        }

        /// <summary>
        /// GZip压缩
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        static byte[] Compress(byte[] rawData)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
            compressedzipStream.Write(rawData, 0, rawData.Length);
            compressedzipStream.Close();
            return ms.ToArray();
        }

        /// <summary>
        /// ZIP解压
        /// </summary>
        /// <param name="zippedData"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] zippedData)
        {
            MemoryStream ms = new MemoryStream(zippedData);
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream outBuffer = new MemoryStream();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                else
                    outBuffer.Write(block, 0, bytesRead);
            }
            compressedzipStream.Close();
            return outBuffer.ToArray();
        }
    }
}
