using System.IO;
using System.Web;
using Utilities.String;

namespace Utilities.Net
{
    public class WebFormHelper
    {
        public static void OutputXls(HttpResponse response, MemoryStream ms)
        {
            response.ContentType = "application/x-xls;charset=UTF-8";
            response.AppendHeader("Content-Disposition", "attachment;filename=" + StringHelper.GetDownloadName("化验报告.xls"));
            byte[] fileBuffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(fileBuffer, 0, (int)ms.Length);
            ms.Close();
            response.BinaryWrite(fileBuffer);
            response.OutputStream.Flush();
            response.OutputStream.Close();
            response.End();
        }

        public static void OutputPdf(HttpResponse response, MemoryStream ms)
        {
            response.ContentType = "application/pdf;charset=UTF-8";
            response.AppendHeader("Content-Disposition", "attachment;filename=" + StringHelper.GetDownloadName("化验报告.pdf"));
            byte[] fileBuffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(fileBuffer, 0, (int)ms.Length);
            ms.Close();
            response.BinaryWrite(fileBuffer);
            response.OutputStream.Flush();
            response.OutputStream.Close();
            response.End();
        }
    }
}
