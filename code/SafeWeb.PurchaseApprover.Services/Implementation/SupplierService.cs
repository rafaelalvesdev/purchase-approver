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
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository Repository { get; set; }

        public SupplierService(ISupplierRepository repository)
        {
            this.Repository = repository;
        }

        public ServiceResult Save(SaveSupplierMessage message)
        {
            Supplier supplier;
            CrudOperation operation;
            if (message.ID.HasValidIdValue())
            {
                supplier = Repository.GetById(message.ID);
                operation = CrudOperation.Update;
                if (supplier == null)
                    return new ServiceResult().SetInvalid().WithMessage(ValidationResources.Supplier_NotFound);

                Mapper.Map(message, supplier);
            }
            else
            {
                supplier = Mapper.Map<Supplier>(message);
                operation = CrudOperation.Create;
            }

            var validation = new SupplierValidator().Execute(supplier);
            if (!validation.IsValid)
                return Mapper.Map<ServiceResult>(validation);

            switch (operation)
            {
                case CrudOperation.Create:
                    Repository.Create(supplier);
                    break;
                case CrudOperation.Update:
                    Repository.Update(supplier);
                    break;
            }

            return supplier.AsServiceResultWithID().SetValid();
        }

        public ServiceResult Get(int supplierID)
        {
            var supplier = Repository.GetById(supplierID);

            if (supplier == null)
                new ServiceResult().SetInvalid().WithMessage(ValidationResources.Supplier_NotFound);

            return supplier.AsServiceResultWithEntity().SetValid();
        }

        public ServiceResult Delete(int supplierID)
        {
            var supplier = Repository.GetById(supplierID);

            Repository.DeleteLogically(supplier);

            return new ServiceResult().SetValid();
        }
    }
}
