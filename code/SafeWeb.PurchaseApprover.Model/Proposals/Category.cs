using FluentValidation;
using SafeWeb.PurchaseApprover.Resources;

namespace SafeWeb.PurchaseApprover.Model.Proposals
{
    public class Category : AuditBaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CategoryValidator : AbstractEntityValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationResources.Name_Empty)
                .Length(3, 100).WithMessage(string.Format(ValidationResources.Name_InvalidLength, 3, 100));

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ValidationResources.Description_Empty)
                .Length(3, 2000).WithMessage(string.Format(ValidationResources.Description_InvalidLength, 3, 2000));
        }
    }
}
