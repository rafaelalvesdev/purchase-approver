using SafeWeb.PurchaseApprover.Model.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Model.Administration
{
    public class UserProfile : BaseEntity<int>
    {
        public string Name { get; set; }
        
        public List<ProfileRole> ProfileRoles { get; set; } = new List<ProfileRole>();
    }    
}
