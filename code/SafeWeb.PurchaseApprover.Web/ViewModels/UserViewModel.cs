using System;

namespace SafeWeb.PurchaseApprover.Web.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public UserProfileViewModel UserProfile { get; set; }
    }
}
