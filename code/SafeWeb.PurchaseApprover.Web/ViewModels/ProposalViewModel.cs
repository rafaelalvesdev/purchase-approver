using SafeWeb.PurchaseApprover.Model.Enums;
using System;

namespace SafeWeb.PurchaseApprover.Web.ViewModels
{
    public class ProposalViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryViewModel Category { get; set; }
        public SupplierViewModel Supplier { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public ProposalStatus Status { get; set; }
    }
}
