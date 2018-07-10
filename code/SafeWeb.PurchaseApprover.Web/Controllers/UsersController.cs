using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Resources;
using SafeWeb.PurchaseApprover.Services.Extensions;
using SafeWeb.PurchaseApprover.Services.Interfaces;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;
using SafeWeb.PurchaseApprover.Web.Requests;
using SafeWeb.PurchaseApprover.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Web.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost]
        public ServiceResult SaveUser([FromServices] IUserService userService, SaveUserRequest request)
        {
            if (CheckMainUserModify(request?.ID ?? 0, out ServiceResult errorResult)) return errorResult;

            var message = Mapper.Map<SaveUserMessage>(request);
            return userService.Save(message);
        }


        [Route("{id}")]
        [HttpGet]
        public ServiceResult GetUser([FromServices] IUserService userService, int id)
        {
            if (CheckMainUserModify(id, out ServiceResult errorResult)) return errorResult;

            var result = userService.Get(id);
            return Mapper.Map<ServiceResult<UserViewModel>>(result);
        }


        [Route("{id}")]
        [HttpDelete]
        public ServiceResult DeleteUser([FromServices] IUserService userService, int id)
        {
            if (CheckMainUserModify(id, out ServiceResult errorResult)) return errorResult;

            var result = userService.Delete(id);
            return result;
        }

        [HttpGet]
        public ServiceResult ListUsers([FromServices] IUserRepository userRepository)
        {
            var result = userRepository.Get();//.Where(x => !x.ID.Equals(1));
            return Mapper.Map<List<UserViewModel>>(result).AsServiceResultWithEntity().SetValid();
        }

        [HttpGet("profiles")]
        public ServiceResult GetProfiles([FromServices] IUserProfileRepository userProfileRepository)
        {
            var result = userProfileRepository.Get();
            return Mapper.Map<List<UserProfileViewModel>>(result).AsServiceResultWithEntity().SetValid();
        }


        private bool CheckMainUserModify(int userId, out ServiceResult errorResult)
        {
            errorResult = null;
            if (userId == 199)
            {
                errorResult = new ServiceResult().SetInvalid().WithMessage(ValidationResources.User_CannotModifyMainUser);
                return true;
            }
            return false;
        }
    }
}