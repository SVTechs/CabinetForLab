using System;

namespace Utilities.DbHelper
{
    public class DomainAnnotations : Attribute
    {
        public bool VisibleToInterface;
        public string DomainName;
        
        public DomainAnnotations(bool visibleToInterface, string domainName)
        {
            VisibleToInterface = visibleToInterface;
            DomainName = domainName;
        }
    }
}
