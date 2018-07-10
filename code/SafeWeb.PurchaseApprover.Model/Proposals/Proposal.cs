using FluentValidation;
using Safeweb.PurchaseApprover.Common.Attributes;
using SafeWeb.PurchaseApprover.Model.Enums;
using SafeWeb.PurchaseApprover.Resources;
using System;

namespace SafeWeb.PurchaseApprover.Model.Proposals
{
    public class Proposal : AuditBaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public ProposalStatus Status { get; set; }
    }

    public class ProposalValidator : AbstractEntityValidator<Proposal>
    {
        public ProposalValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationResources.Name_Empty)
                .Length(3, 100).WithMessage(x => string.Format(ValidationResources.Name_InvalidLength, 3, 100));

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ValidationResources.Description_Empty)
                .Length(3, 2000).WithMessage(string.Format(ValidationResources.Description_InvalidLength, 3, 20));

            RuleFor(x => x.Category)
                .NotNull().WithMessage(ValidationResources.Category_Invalid);

            RuleFor(x => x.Supplier)
                .NotNull().WithMessage(ValidationResources.Supplier_Invalid);

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage(ValidationResources.Date_Empty);

            RuleFor(x => x.Amount)
                .GreaterThan(0m).WithMessage(string.Format(ValidationResources.Amount_GreatherThan, 0m.ToString("C")));
        }
    }
}
