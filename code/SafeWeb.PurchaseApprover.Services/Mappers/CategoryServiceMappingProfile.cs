using AutoMapper;
using SafeWeb.PurchaseApprover.Model.Proposals;
using SafeWeb.PurchaseApprover.Services.Messages;

namespace SafeWeb.PurchaseApprover.Services.Mappers
{
    public class CategoryServiceMappingProfile : Profile
    {
        public CategoryServiceMappingProfile()
        {
            CreateMap<SaveCategoryMessage, Category>();            
        }
    }
}
