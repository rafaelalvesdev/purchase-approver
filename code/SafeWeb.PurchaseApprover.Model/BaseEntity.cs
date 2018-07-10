using System.ComponentModel.DataAnnotations;

namespace SafeWeb.PurchaseApprover.Model
{
    public abstract class BaseEntity<TKey> 
    {
        [Key]
        public virtual TKey ID { get; set; }

        public virtual bool IsDeleted { get; set; }
    }
}
