using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Services.Extensions;
using SafeWeb.PurchaseApprover.Services.Interfaces;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;
using SafeWeb.PurchaseApprover.Web.Requests;
using SafeWeb.PurchaseApprover.Web.ViewModels;
using System.Collections.Generic;

namespace SafeWeb.PurchaseApprover.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        [HttpPost]
        public ServiceResult SaveCategory([FromServices] ICategoryService categoryService, SaveCategoryRequest request)
        {
            var message = Mapper.Map<SaveCategoryMessage>(request);
            return categoryService.Save(message);
        }


        [Route("{id}")]
        [HttpGet]
        public ServiceResult GetCategory([FromServices] ICategoryService categoryService, int id)
        {
            var result = categoryService.Get(id);
            return Mapper.Map<ServiceResult<CategoryViewModel>>(result);
        }


        [Route("{id}")]
        [HttpDelete]
        public ServiceResult DeleteCategory([FromServices] ICategoryService categoryService, int id)
        {
            var result = categoryService.Delete(id);
            return result;
        }
        
        [HttpGet]
        public ServiceResult ListCategories([FromServices] ICategoryRepository categoryRepository)
        {
            var result = categoryRepository.Get();
            return Mapper.Map<List<CategoryViewModel>>(result).AsServiceResultWithEntity().SetValid();
        }
    }
}