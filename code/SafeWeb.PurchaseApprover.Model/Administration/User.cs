using FluentValidation;
using SafeWeb.PurchaseApprover.Resources;
using System;

namespace SafeWeb.PurchaseApprover.Model.Administration
{
    public class User : AuditBaseEntity<int>
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public UserProfile UserProfile { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserValidator : AbstractEntityValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationResources.Name_Empty)
                .Length(3, 100).WithMessage(string.Format(ValidationResources.Name_InvalidLength, 3, 100));

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage(ValidationResources.BirthDate_Empty);

            RuleFor(x => x.UserProfile)
                .NotNull().WithMessage(ValidationResources.User_UserProfile_Null);
        }
    }
}