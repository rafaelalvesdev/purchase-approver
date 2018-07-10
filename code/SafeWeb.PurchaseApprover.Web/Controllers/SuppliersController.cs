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
    public class SuppliersController : BaseController
    {
        [HttpPost]
        public ServiceResult SaveSupplier([FromServices] ISupplierService supplierService, SaveSupplierRequest request)
        {
            var message = Mapper.Map<SaveSupplierMessage>(request);
            return supplierService.Save(message);
        }


        [Route("{id}")]
        [HttpGet]
        public ServiceResult GetSupplier([FromServices] ISupplierService supplierService, int id)
        {
            var result = supplierService.Get(id);
            return Mapper.Map<ServiceResult<SupplierViewModel>>(result);
        }


        [Route("{id}")]
        [HttpDelete]
        public ServiceResult DeleteSupplier([FromServices] ISupplierService supplierService, int id)
        {
            var result = supplierService.Delete(id);
            return result;
        }

        [HttpGet]
        public ServiceResult ListSuppliers([FromServices] ISupplierRepository supplierRepository)
        {
            var result = supplierRepository.Get();
            return Mapper.Map<List<SupplierViewModel>>(result).AsServiceResultWithEntity().SetValid();
        }
    }
}