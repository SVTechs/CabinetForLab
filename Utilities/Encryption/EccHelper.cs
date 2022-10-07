using System;
using System.Text;
using Virgil.SDK.Cryptography;

// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace Utilities.Encryption
{
    /// <summary>
    /// ECIES
    /// </summary>
    public class EccHelper
    {
        public class EccKey
        {
            public byte[] PublicKey, PrivateKey;

            public EccKey(byte[] publicKey, byte[] privateKey)
            {
                PublicKey = publicKey;
                PrivateKey = privateKey;
            }

            public string GetPublicKey()
            {
                return Convert.ToBase64String(PublicKey);
            }

            public string GetPrivateKey()
            {
                return Convert.ToBase64String(PrivateKey);
            }
        }

        public static EccKey GenerateKey()
        {
            var crypto = new ManagedCrypto();
            var aliceKeys = crypto.GenerateKeys();
            byte[] publicKey = crypto.ExportPublicKey(aliceKeys.PublicKey);
            byte[] privateKey = crypto.ExportPrivateKey(aliceKeys.PrivateKey);
            return new EccKey(publicKey, privateKey);
        }

        public static string Encrypt(string plain, string encKey)
        {
            var crypto = new ManagedCrypto();
            byte[] keyBytes = Convert.FromBase64String(encKey);
            var importedKey = crypto.ImportPublicKey(keyBytes);
            var plaintext = Encoding.Default.GetBytes(plain);
            var cipherData = crypto.Encrypt(plaintext, importedKey);
            return Convert.ToBase64String(cipherData);
        }

        public static string Decrypt(string encData, string decKey)
        {
            var crypto = new ManagedCrypto();
            byte[] keyBytes = Convert.FromBase64String(decKey);
            var importedKey = crypto.ImportPrivateKey(keyBytes);
            byte[] encBytes = Convert.FromBase64String(encData);
            var cipherData = crypto.Decrypt(encBytes, importedKey);
            return Encoding.Default.GetString(cipherData);
        }
    }
}
