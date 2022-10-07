using System;
using System.Web;
using WebConsole.BLL;

namespace WebConsole.Framework.DataProcessing
{
    /// <summary>
    /// DynamicGrid 的摘要说明
    /// </summary>
    public class DynamicGrid : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            try
            {
                string funcGroup = context.Request.Form["funcGroup"];
                string gridLayout = context.Request.Form["gridLayout"].Trim().TrimEnd(',');
                int result = BllGridOutput.ClearGridOutput(funcGroup, out var ex);
                if (result < 0 || ex != null)
                {
                    context.Response.Write("-10");
                    return;
                }
                if (gridLayout.Length == 0)
                {
                    context.Response.Write("1");
                    return;
                }
                string[] infoArray = gridLayout.Split(',');
                for (int i = 0; i < infoArray.Length; i++)
                {
                    string[] layoutInfo = infoArray[i].Split('|');
                    result = BllGridOutput.AddGridOutput(funcGroup, layoutInfo[0], layoutInfo[1], i + 1, out _);
                    if (result <= 0)
                    {
                        context.Response.Write("-20");
                        return;
                    }
                }
                context.Response.Write("1");
            }
            catch (Exception)
            {
                context.Response.Write("-1");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}