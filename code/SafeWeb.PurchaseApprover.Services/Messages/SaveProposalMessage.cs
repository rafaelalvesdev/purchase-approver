using SafeWeb.PurchaseApprover.Model.Enums;
using System;

namespace SafeWeb.PurchaseApprover.Services.Messages
{
    public class SaveProposalMessage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public decimal Amount { get; set; }
    }
}
