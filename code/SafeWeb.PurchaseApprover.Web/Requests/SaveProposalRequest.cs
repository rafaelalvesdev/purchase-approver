namespace SafeWeb.PurchaseApprover.Web.Requests
{
    public class SaveProposalRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public decimal Amount { get; set; }
    }
}