using AutoMapper;
using SafeWeb.PurchaseApprover.Model.Proposals;
using SafeWeb.PurchaseApprover.Services.Messages;

namespace SafeWeb.PurchaseApprover.Services.Mappers
{
    public class SupplierServiceMappingProfile : Profile
    {
        public SupplierServiceMappingProfile()
        {
            CreateMap<SaveSupplierMessage, Supplier>();            
        }
    }
}
