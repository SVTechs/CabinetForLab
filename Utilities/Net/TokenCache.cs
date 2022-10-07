using System;
using System.Collections;
using System.Linq;
using Utilities.Encryption;

namespace Utilities.Net
{
    public class TokenCache
    {
        public string UserId { get; set; }

        public object UserInfo { get; set; }

        public string TokenKey { get; set; }

        public string ClientPublicKey { get; set; }

        public Hashtable Permission { get; set; }

        public DateTime ExpireTime { get; set; }

        public static string SignContent(string userId, string timeStamp, string nonce, string tokenKey, string content)
        {
            var signStr = userId + timeStamp + nonce + tokenKey + content;
            var sortStr = string.Concat(signStr.OrderBy(c => c));
            return Md5Encode.GetWebMd5(sortStr);
        }


        public static Hashtable GenerateToken(string userId, string tokenKey, string content)
        {
            Hashtable token = new Hashtable();
            Random rd = new Random();
            string nonce = rd.Next(100000, 999999).ToString();
            string timeStamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000).ToString("F0");
            string sign = SignContent(userId, timeStamp, nonce, tokenKey, content);
            token["userid"] = userId;
            token["timestamp"] = timeStamp;
            token["nonce"] = nonce;
            token["signature"] = sign;
            return token;
        }
    }
}
