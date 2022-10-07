using System;

namespace Utilities.DbHelper
{
    public class HbAnnotations : Attribute
    {
        public string ValDesp;

        public HbAnnotations(string valDesp)
        {
            ValDesp = valDesp;
        }
    }
}
