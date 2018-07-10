using AutoMapper;
using Safeweb.PurchaseApprover.Common.Attributes;
using Safeweb.PurchaseApprover.Common.Extensions;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Proposals;
using SafeWeb.PurchaseApprover.Resources;
using SafeWeb.PurchaseApprover.Services.Configurations;
using SafeWeb.PurchaseApprover.Services.Enums;
using SafeWeb.PurchaseApprover.Services.Extensions;
using SafeWeb.PurchaseApprover.Services.Interfaces;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;
using System;

namespace SafeWeb.PurchaseApprover.Services.Implementation
{
    public class ProposalService : IProposalService
    {
        IProposalRepository Repository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        ISupplierRepository SupplierRepository { get; set; }
        SystemConfigurations Configurations { get; set; }

        public ProposalService(IProposalRepository repository, SystemConfigurations configurations, ICategoryRepository categoryRepository, ISupplierRepository supplierRepository)
        {
            this.Repository = repository;
            this.Configurations = configurations;
            this.CategoryRepository = categoryRepository;
            this.SupplierRepository = supplierRepository;
        }

        public ServiceResult SaveProposalFile(SaveProposalFileMessage message)
        {


            throw new NotImplementedException();
        }

        public ServiceResult Save(SaveProposalMessage message)
        {
            Proposal proposal;
            CrudOperation operation;
            if (message.ID.HasValidIdValue())
            {
                proposal = Repository.GetById(message.ID);

                operation = CrudOperation.Update;
                if (proposal == null)
                    new ServiceResult().SetInvalid().WithMessage(ValidationResources.Proposal_NotFound);
                
                // Edit validation
                if(!EntityCanBeModified.CheckIfEntityCanBeModified(proposal.Status))
                    return new ServiceResult().SetInvalid().WithMessage(ValidationResources.Proposal_CannotBeModified_Approved);

                if((proposal.Date - DateTime.Now).TotalHours > Configurations.PurchaseProposal_HoursToExpire)
                    return new ServiceResult().SetInvalid().WithMessage(ValidationResources.Proposal_CannotBeModified_Expired);

                Mapper.Map(message, proposal);
            }
            else
            {
                proposal = Mapper.Map<Proposal>(message);
                operation = CrudOperation.Create;
            }

            proposal.Category = CategoryRepository.GetById(message.CategoryID);
            proposal.Supplier = SupplierRepository.GetById(message.SupplierID);

            var validation = new ProposalValidator().Execute(proposal);
            if (!validation.IsValid)
                return Mapper.Map<ServiceResult>(validation);

            switch (operation)
            {
                case CrudOperation.Create:
                    Repository.Create(proposal);
                    break;
                case CrudOperation.Update:
                    Repository.Update(proposal);
                    break;
            }

            return proposal.AsServiceResultWithID().SetValid();
        }

        public ServiceResult Get(int proposalID)
        {
            var proposal = Repository.GetById(proposalID);

            if (proposal == null)
                new ServiceResult().SetInvalid().WithMessage(ValidationResources.Proposal_NotFound);

            return proposal.AsServiceResultWithEntity().SetValid();
        }

        public ServiceResult Delete(int proposalID)
        {
            var proposal = Repository.GetById(proposalID);

            Repository.DeleteLogically(proposal);

            return new ServiceResult().SetValid();
        }
    }
}
