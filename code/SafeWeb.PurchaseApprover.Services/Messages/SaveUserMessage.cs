using System;

namespace SafeWeb.PurchaseApprover.Services.Messages
{
    public class SaveUserMessage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserProfileID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
