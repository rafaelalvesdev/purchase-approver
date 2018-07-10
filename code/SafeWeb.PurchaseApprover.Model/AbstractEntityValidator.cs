using FluentValidation;
using FluentValidation.Results;
using System;

namespace SafeWeb.PurchaseApprover.Model
{
    public abstract class AbstractEntityValidator<T> : AbstractValidator<T>
    {
        public ValidationResult Execute(T instance)
        {
            var type = this.GetType();
            var validator = Activator.CreateInstance(type) as AbstractEntityValidator<T>;
            return validator.Validate(instance);
        }
    }
}
