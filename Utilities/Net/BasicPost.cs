using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace Utilities.Net
{
    public class BasicPost
    {
        private static CookieContainer globalCookie = new CookieContainer();
        private static WebProxy proxy = null;

        public static int SetProxy(string proxyIp, int port)
        {
            proxy = new WebProxy(string.Format("{0}:{1}", proxyIp, port));
            return 1;
        }

        public static int SetProxy(string pacAddr)
        {
            proxy = new WebProxy(pacAddr);
            return 1;
        }

        public static int DownloadFile(string url, string filePath, bool useProxy, string referer = null)
        {
            try
            {
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(new Uri(url));
                hwr.CookieContainer = globalCookie;
                hwr.Method = "GET";
                if (useProxy && proxy != null) hwr.Proxy = proxy;
                if (!string.IsNullOrEmpty(referer))
                {
                    hwr.Referer = referer;
                }
                hwr.AddRange(0, 10000000);
                using (Stream stream = hwr.GetResponse().GetResponseStream())
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        byte[] bytes = new byte[102400];
                        int n = 1;
                        while (n > 0)
                        {
                            n = stream.Read(bytes, 0, 10240);
                            fs.Write(bytes, 0, n);
                        }
                    }
                    return 1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary></summary>
        /// <param name="postData">The data to post.</param>
        /// <param name="url">the url to post to.</param>
        /// <param name="sType">the Type to Connect.</param>
        /// <param name="customCookie"></param>
        /// <param name="strEncoding"></param>
        /// <returns>Returns the result of the post.</returns>
        public static string PostData(string url, string postData, int sType, bool useProxy, CookieContainer customCookie = null,
            string strEncoding = "UTF-8")
        {
            try
            {
                HttpWebRequest request = null;
                ServicePointManager.Expect100Continue = false;
                if (sType == 0)
                {
                    Uri uri = new Uri(url);
                    request = (HttpWebRequest)WebRequest.Create(uri);
                    if (customCookie == null) request.CookieContainer = globalCookie;
                    else request.CookieContainer = customCookie;
                    request.Method = "POST";
                    if (useProxy && proxy != null) request.Proxy = proxy;
                    request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = postData.Length;
                    using (Stream writeStream = request.GetRequestStream())
                    {
                        Encoding encoding = Encoding.GetEncoding(strEncoding);
                        byte[] bytes = encoding.GetBytes(postData);
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }
                else
                {
                    Uri uri = new Uri(url + "?" + postData);
                    request = (HttpWebRequest)WebRequest.Create(uri);
                    if (customCookie == null) request.CookieContainer = globalCookie;
                    else request.CookieContainer = customCookie;
                    request.Method = "GET";
                    request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                }
                string result = string.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (!response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader readStream = new StreamReader(responseStream, Encoding.GetEncoding(strEncoding)))
                            {
                                result = readStream.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        using (GZipStream responseStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader readStream = new StreamReader(responseStream, Encoding.GetEncoding(strEncoding)))
                            {
                                result = readStream.ReadToEnd();
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool PostJson(string url, string postData, out string response, CookieContainer customCookie = null,
            string strEncoding = "UTF-8")
        {
            try
            {
                HttpWebRequest request = null;
                ServicePointManager.Expect100Continue = false;

                Uri uri = new Uri(url);
                request = (HttpWebRequest)WebRequest.Create(uri);
                if (customCookie == null) request.CookieContainer = globalCookie;
                else request.CookieContainer = customCookie;
                request.Method = "POST";
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.ContentType = "application/json";
                using (Stream writeStream = request.GetRequestStream())
                {
                    Encoding encoding = Encoding.GetEncoding(strEncoding);
                    byte[] bytes = encoding.GetBytes(postData);
                    writeStream.Write(bytes, 0, bytes.Length);
                }
                string result = string.Empty;
                using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    if (!httpResponse.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (Stream responseStream = httpResponse.GetResponseStream())
                        {
                            using (StreamReader readStream = new StreamReader(responseStream, Encoding.GetEncoding(strEncoding)))
                            {
                                result = readStream.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        using (GZipStream responseStream = new GZipStream(httpResponse.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader readStream = new StreamReader(responseStream, Encoding.GetEncoding(strEncoding)))
                            {
                                result = readStream.ReadToEnd();
                            }
                        }
                    }
                }
                response = result;
                return true;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
        }

        public static bool PostJsonWithToken(string url, string postData, out string response, Hashtable header = null,
            string strEncoding = "UTF-8")
        {
            try
            {
                HttpWebRequest request = null;
                ServicePointManager.Expect100Continue = false;

                Uri uri = new Uri(url);
                request = (HttpWebRequest)WebRequest.Create(uri);
                if (header != null)
                {
                    foreach (DictionaryEntry de in header)
                    {
                        request.Headers.Add(de.Key.ToString(), de.Value.ToString());
                    }
                }
                request.Method = "POST";
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.ContentType = "application/json";
                using (Stream writeStream = request.GetRequestStream())
                {
                    Encoding encoding = Encoding.GetEncoding(strEncoding);
                    byte[] bytes = encoding.GetBytes(postData);
                    writeStream.Write(bytes, 0, bytes.Length);
                }
                string result = string.Empty;
                using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
                {
                    if (!httpResponse.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (Stream responseStream = httpResponse.GetResponseStream())
                        {
                            using (StreamReader readStream = new StreamReader(responseStream, Encoding.GetEncoding(strEncoding)))
                            {
                                result = readStream.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        using (GZipStream responseStream = new GZipStream(httpResponse.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader readStream = new StreamReader(responseStream, Encoding.GetEncoding(strEncoding)))
                            {
                                result = readStream.ReadToEnd();
                            }
                        }
                    }
                }
                response = result;
                return true;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
        }
    }
}
