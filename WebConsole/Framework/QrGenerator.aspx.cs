using System;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.BarCode.Generation;
using Aspose.BarCode.Generation.V3;

namespace WebConsole.Framework
{
    public partial class QrGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap barBitmap = null;
            BarcodeGenerator barCodeGenerator;
            string qrType = Request.QueryString["type"], data = Request.QueryString["data"];
            switch (qrType)
            {
                case "1":
                    barCodeGenerator = new BarcodeGenerator(EncodeTypes.Code128, data);
                    barCodeGenerator.Parameters.Barcode.XDimension.Millimeters = 1f;
                    barCodeGenerator.Parameters.Barcode.CodeTextParameters.Location = CodeLocation.None;
                    barBitmap = barCodeGenerator.GenerateBarCodeImage();
                    break;
                case "2":
                    barCodeGenerator = new BarcodeGenerator(EncodeTypes.QR, data);
                    barBitmap = barCodeGenerator.GenerateBarCodeImage();
                    break;
            }
            if (barBitmap == null) return;
            Response.ContentType = "image/jpeg";
            barBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
        }
    }
}