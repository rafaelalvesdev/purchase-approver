using AutoMapper;
using Safeweb.PurchaseApprover.Common.Extensions;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Proposals;
using SafeWeb.PurchaseApprover.Resources;
using SafeWeb.PurchaseApprover.Services.Enums;
using SafeWeb.PurchaseApprover.Services.Extensions;
using SafeWeb.PurchaseApprover.Services.Interfaces;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;

namespace SafeWeb.PurchaseApprover.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository Repository { get; set; }

        public CategoryService(ICategoryRepository repository)
        {
            this.Repository = repository;
        }

        public ServiceResult Save(SaveCategoryMessage message)
        {
            Category category;
            CrudOperation operation;
            if (message.ID.HasValidIdValue())
            {
                category = Repository.GetById(message.ID);
                operation = CrudOperation.Update;
                if (category == null)
                    return new ServiceResult().SetInvalid().WithMessage(ValidationResources.Category_NotFound);

                Mapper.Map(message, category);
            }
            else
            {
                category = Mapper.Map<Category>(message);
                operation = CrudOperation.Create;
            }

            var validation = new CategoryValidator().Execute(category);
            if (!validation.IsValid)
                return Mapper.Map<ServiceResult>(validation);

            switch (operation)
            {
                case CrudOperation.Create:
                    Repository.Create(category);
                    break;
                case CrudOperation.Update:
                    Repository.Update(category);
                    break;
            }

            return category.AsServiceResultWithID().SetValid();
        }

        public ServiceResult Get(int categoryID)
        {
            var category = Repository.GetById(categoryID);

            if (category == null)
                new ServiceResult().SetInvalid().WithMessage(ValidationResources.Category_NotFound);

            return category.AsServiceResultWithEntity().SetValid();
        }

        public ServiceResult Delete(int categoryID)
        {
            var category = Repository.GetById(categoryID);

            Repository.DeleteLogically(category);

            return new ServiceResult().SetValid();
        }
    }
}
