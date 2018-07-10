using AutoMapper;
using SafeWeb.PurchaseApprover.Model.Proposals;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Web.Requests;
using SafeWeb.PurchaseApprover.Web.ViewModels;

namespace SafeWeb.PurchaseApprover.Web.Mappers
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<SaveCategoryRequest, SaveCategoryMessage>();

            CreateMap<Category, CategoryViewModel>();
        }
    }
}
