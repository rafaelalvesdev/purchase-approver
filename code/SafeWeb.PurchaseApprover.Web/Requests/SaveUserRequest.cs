using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeWeb.PurchaseApprover.Web.Requests
{
    public class SaveUserRequest
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? UserProfileID { get; set; }
    }
}
