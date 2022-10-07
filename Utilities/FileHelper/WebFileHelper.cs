using System.Collections.Generic;
using System.IO;

namespace Utilities.FileHelper
{
    public class WebFileHelper
    {
        private static readonly List<string> ValidFileTypes = new List<string> { "DOC", "DOCX", "XLS", "XLSX", "CSV", "PPT", "PPTX", "RAR", "ZIP" };

        public static bool ValidateFileType(string fileName)
        {
            string fileExt = Path.GetExtension(fileName)?.ToUpper().TrimStart('.');
            if (string.IsNullOrEmpty(fileExt)) return false;
            if (ValidFileTypes.Contains(fileExt)) return true;
            return false;
        }
    }
}
