using System;

namespace Utilities.DbHelper
{
    public class SqlAnnotations : Attribute
    {
        public string ColumnMapping;

        public SqlAnnotations(string columnMapping)
        {
            ColumnMapping = columnMapping;
        }
    }
}
