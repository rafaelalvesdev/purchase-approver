using SafeWeb.PurchaseApprover.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeWeb.PurchaseApprover.Model.Administration
{
    public class ProfileRole
    {
        public SystemRoles Role { get; set; }

        public int UserProfileID { get; set; }

        public static implicit operator SystemRoles(ProfileRole pr)
        {
            return pr.Role;
        }

        public static implicit operator ProfileRole(SystemRoles pr)
        {
            return new ProfileRole() {
                Role = pr
            };
        }
    }


    public static class ProfileRoleExtensions
    {
        public static ProfileRole FromSystemRole(this SystemRoles systemRole)
        {
            return new ProfileRole()
            {
                Role = systemRole
            };
        }
    }
}
