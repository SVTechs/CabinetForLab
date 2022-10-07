using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

// ReSharper disable UnusedMember.Global

namespace Utilities.Encryption
{
    public class NRsaHelper
    {
        public class KeyPair
        {
            public string PrivateKey;
            public string PublicKey;
        }

        public static KeyPair GenerateKeyPair(int keyLength)
        {
            RsaKeyPairGenerator rsaKeyPairGenerator = new RsaKeyPairGenerator();
            RsaKeyGenerationParameters rsaKeyGenerationParameters = new RsaKeyGenerationParameters(BigInteger.ValueOf(10001), new SecureRandom(), keyLength, 25);
            rsaKeyPairGenerator.Init(rsaKeyGenerationParameters);//初始化参数   
            AsymmetricCipherKeyPair keyPair = rsaKeyPairGenerator.GenerateKeyPair();
            AsymmetricKeyParameter publicKey = keyPair.Public;//公钥   
            AsymmetricKeyParameter privateKey = keyPair.Private;//私钥   

            KeyPair ht = new KeyPair();

            TextWriter textWriter = new StringWriter();
            PemWriter pemWriter = new PemWriter(textWriter);
            pemWriter.WriteObject(privateKey);
            pemWriter.Writer.Flush();
            ht.PrivateKey = textWriter.ToString().Replace("\r\n", "");

            TextWriter textPubWriter = new StringWriter();
            PemWriter pubPemWriter = new PemWriter(textPubWriter);
            pubPemWriter.WriteObject(publicKey);
            pubPemWriter.Writer.Flush();
            ht.PublicKey = textPubWriter.ToString().Replace("\r\n", "");

            return ht;
        }


        #region  加密

        /// <summary>
        /// RSA加密PEM秘钥（普通PKCS#1格式）
        /// </summary>
        /// <param name="publicKeyPem"></param>
        /// <param name="data"></param>
        /// <param name="keyLength"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string EncryptPem(string data, string publicKeyPem, int keyLength = 2048, string encoding = "UTF-8")
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(publicKeyPem))
            {
                throw new ArgumentException("Invalid Public Key");
            }

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.LoadPublicKeyPEM(publicKeyPem);//载入公钥

                StringBuilder output = new StringBuilder();
                byte[] plainData = Encoding.UTF8.GetBytes(data);
                int dataLength = plainData.Length;
                int encLength = keyLength / 16;
                for (int i = 0; i < dataLength; i += encLength)
                {
                    int takeLength = dataLength - i < encLength ? dataLength - i : encLength;
                    byte[] encryptData = rsa.Encrypt(plainData.Skip(i).Take(takeLength).ToArray(), false);
                    output.Append(Convert.ToBase64String(encryptData) + "|");
                }
                return output.ToString().TrimEnd('|');
            }
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publicKeyCSharp"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string EncryptCSharp(string publicKeyCSharp, string data, string encoding = "UTF-8")
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(publicKeyCSharp))
            {
                throw new ArgumentException("Invalid Public Key");
            }

            using (var rsa = new RSACryptoServiceProvider())
            {
                var inputBytes = Encoding.GetEncoding(encoding).GetBytes(data);//有含义的字符串转化为字节流

                rsa.FromXmlString(publicKeyCSharp);//载入公钥
                int bufferSize = (rsa.KeySize / 8) - 11;//单块最大长度
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    { //分段加密
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var encryptedBytes = rsa.Encrypt(temp, false);
                        outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    return Convert.ToBase64String(outputStream.ToArray());//转化为字节流方便传输
                }
            }
        }

        #endregion

        #region 解密
        /// <summary>
        /// RSA解密（普通PKCS#1格式）
        /// </summary>
        /// <param name="privateKeyPem"></param>
        /// <param name="encryptedString"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DecryptPem(string encryptedString, string privateKeyPem, string encoding = "UTF-8")
        {
            if (string.IsNullOrEmpty(encryptedString))
            {
                return string.Empty;
            }
            if (string.IsNullOrWhiteSpace(privateKeyPem))
            {
                throw new ArgumentException("Invalid Private Key");
            }
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.LoadPrivateKeyPEM(privateKeyPem);

                string[] blockList = encryptedString.Split('|');
                List<byte> byteSource = new List<byte>();
                for (int i = 0; i < blockList.Length; i++)
                {
                    byte[] encryptedData = Convert.FromBase64String(blockList[i]);
                    byteSource.AddRange(rsa.Decrypt(encryptedData, false));
                }
                return Encoding.UTF8.GetString(byteSource.ToArray());
            }
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="privateKeyCSharp"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DecryptCSharp(string privateKeyCSharp, string data, string encoding = "UTF-8")
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(privateKeyCSharp))
            {
                throw new ArgumentException("Invalid Private Key");
            }

            using (var rsa = new RSACryptoServiceProvider())
            {
                var inputBytes = Convert.FromBase64String(data);
                rsa.FromXmlString(privateKeyCSharp);
                int bufferSize = rsa.KeySize / 8;
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    {
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var rawBytes = rsa.Decrypt(temp, false);
                        outputStream.Write(rawBytes, 0, rawBytes.Length);
                    }
                    return Encoding.GetEncoding(encoding).GetString(outputStream.ToArray());
                }
            }
        }

        #endregion


        #region 加签

        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="privateKeyPem">私钥</param>
        /// <param name="data">待签名的内容</param>
        /// <param name="hashAlgorithm"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string RsaSignPem(string data, string privateKeyPem, string hashAlgorithm = "MD5", string encoding = "UTF-8")
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.LoadPrivateKeyPEM(privateKeyPem);//加载私钥   
            var dataBytes = Encoding.GetEncoding(encoding).GetBytes(data);
            var hashByteSignature = rsa.SignData(dataBytes, hashAlgorithm);
            return Convert.ToBase64String(hashByteSignature);
        }

        /// <summary>
        /// RSA签名CSharp
        /// </summary>
        /// <param name="privateKeyCSharp">私钥</param>
        /// <param name="data">待签名的内容</param>
        /// <param name="hashAlgorithm"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string RsaSignCSharp(string data, string privateKeyCSharp, string hashAlgorithm = "MD5", string encoding = "UTF-8")
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKeyCSharp);//加载私钥   
            var dataBytes = Encoding.GetEncoding(encoding).GetBytes(data);
            var hashByteSignature = rsa.SignData(dataBytes, hashAlgorithm);
            return Convert.ToBase64String(hashByteSignature);
        }

        #endregion

        #region 验签

        /// <summary> 
        /// 验证签名PEM
        /// </summary>
        /// <param name="data"></param>
        /// <param name="publicKeyPem"></param>
        /// <param name="signature"></param>
        /// <param name="hashAlgorithm"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static bool VerifyPem(string data, string publicKeyPem, string signature, string hashAlgorithm = "MD5", string encoding = "UTF-8")
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //导入公钥，准备验证签名
            rsa.LoadPublicKeyPEM(publicKeyPem);
            //返回数据验证结果
            byte[] encodedData = Encoding.GetEncoding(encoding).GetBytes(data);
            byte[] rgbSignature = Convert.FromBase64String(signature);

            return rsa.VerifyData(encodedData, hashAlgorithm, rgbSignature);
        }

        /// <summary> 
        /// 验证签名CSharp
        /// </summary>
        /// <param name="data"></param>
        /// <param name="publicKeyCSharp"></param>
        /// <param name="signature"></param>
        /// <param name="hashAlgorithm"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static bool VerifyCSharp(string data, string publicKeyCSharp, string signature, string hashAlgorithm = "MD5", string encoding = "UTF-8")
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //导入公钥，准备验证签名
            rsa.LoadPublicKeyPEM(publicKeyCSharp);
            //返回数据验证结果
            byte[] encodedData = Encoding.GetEncoding(encoding).GetBytes(data);
            byte[] rgbSignature = Convert.FromBase64String(signature);

            return rsa.VerifyData(encodedData, hashAlgorithm, rgbSignature);
        }

        #endregion
    }
}
