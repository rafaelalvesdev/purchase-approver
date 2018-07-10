﻿using AutoMapper;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Model.Enums;
using SafeWeb.PurchaseApprover.Model.Proposals;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;
using SafeWeb.PurchaseApprover.Web.Requests;
using SafeWeb.PurchaseApprover.Web.ViewModels;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Web.Mappers
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<SaveSupplierRequest, SaveSupplierMessage>();

            CreateMap<Supplier, SupplierViewModel>();
        }
    }
}
