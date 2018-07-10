using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWeb.PurchaseApprover.Model
{
    public class AuditBaseEntity<TKey> : BaseEntity<TKey> 
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
