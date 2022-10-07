using Utilities.Encryption;

namespace Utilities.Net
{
    public class SoapAuthHeader : System.Web.Services.Protocols.SoapHeader
    {
        public string UserName { set; get; }
        public string Password { set; get; }

        public SoapAuthHeader() {}

        public SoapAuthHeader(string userName, string passWord)
        {
            UserName = userName;
            Password = passWord;
        }

        public SoapAuthHeader(string userName, string password, string pubKey)
        {
            UserName = JRsaHelper.EncryptString(userName, pubKey);
            Password = JRsaHelper.EncryptString(password, pubKey);
        }
    }
}
