using SafeWeb.PurchaseApprover.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeWeb.PurchaseApprover.Web.ViewModels
{
    public class UserProfileViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<SystemRoles> ProfileRoles { get; set; } = new List<SystemRoles>();
    }
}
