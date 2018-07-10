using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeWeb.PurchaseApprover.Model.Administration
{
    public class Configuration
    {
        [Key]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
