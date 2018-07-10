using AutoMapper;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;

namespace SafeWeb.PurchaseApprover.Services.Mappers
{
    public class UserServiceMappingProfile : Profile
    {
        public UserServiceMappingProfile()
        {
            CreateMap<SaveUserMessage, User>();            
        }
    }
}
