using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Services.Interfaces;
using SafeWeb.PurchaseApprover.Services.Results;
using SafeWeb.PurchaseApprover.Web.Requests;
using SafeWeb.PurchaseApprover.Web.ViewModels;
using SafeWeb.PurchaseApprover.Services.Extensions;
using System;

namespace SafeWeb.PurchaseApprover.Web.Controllers
{
    public class LoginController : BaseController
    {
        [HttpPost]
        [Route("signin")]
        public ServiceResult SignIn([FromServices] IUserService userService, SignInRequest request)
        {            
            var result = userService.GetUserByUsernameAndPassword(request.Username, request.Password);
            
            if (result.IsValid)
            {
                var user = (result as ServiceResult<User>).Data;
                HttpContext.Session.SetString("LoggedUser", JsonConvert.SerializeObject(user));
                return Mapper.Map<ServiceResult<UserViewModel>>(result);
            }

            return result;
        }


        [HttpGet]
        [Route("signout")]
        public ServiceResult SignOut()
        {
            HttpContext.Session.Remove("LoggedUser");
            return true.AsServiceResultWithEntity().SetValid();
        }


        [HttpGet]
        [Route("check")]
        public ServiceResult Check()
        {
            return true.AsServiceResultWithEntity().SetValid();
            User user = null;
            try
            {
                user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("LoggedUser"));
            } catch(Exception e) { }

            if(user == null)
                return false.AsServiceResultWithEntity().SetInvalid();
            else 
                return user.AsServiceResultWithEntity().SetValid();
        }
    }
}