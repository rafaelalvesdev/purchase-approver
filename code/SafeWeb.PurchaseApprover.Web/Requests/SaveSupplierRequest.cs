namespace SafeWeb.PurchaseApprover.Web.Requests
{
    public class SaveSupplierRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
