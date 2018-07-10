using FluentValidation;
using Safeweb.PurchaseApprover.Common.Validators;
using SafeWeb.PurchaseApprover.Resources;

namespace SafeWeb.PurchaseApprover.Model.Proposals
{
    public class Supplier : AuditBaseEntity<int>
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class SupplierValidator : AbstractEntityValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationResources.Name_Empty)
                .Length(3, 100).WithMessage(string.Format(ValidationResources.Name_InvalidLength, 3, 100));

            RuleFor(x => x.DocumentNumber)
                .Must(x => DocumentValidation.IsValidDocument(x))
                .WithMessage(ValidationResources.DocumentNumber_Invalid);

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage(ValidationResources.Phone_Empty)
                .Length(10, 20).WithMessage(string.Format(ValidationResources.Phone_Invalid, 10, 20));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationResources.Email_Empty)
                .EmailAddress().WithMessage(ValidationResources.Email_Invalid);
        }
    }
}
