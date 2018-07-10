using AutoMapper;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Model.Enums;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;
using SafeWeb.PurchaseApprover.Web.Requests;
using SafeWeb.PurchaseApprover.Web.ViewModels;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Web.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<SaveUserRequest, SaveUserMessage>();

            CreateMap<User, UserViewModel>();

            CreateMap<UserProfile, UserProfileViewModel>()
                .ForMember(x => x.ProfileRoles, opt => opt.ResolveUsing(src =>
                {
                    return src.ProfileRoles.Select(x => x.Role).ToList();
                }));

        }
    }
}
