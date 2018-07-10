using AutoMapper;
using FluentValidation.Results;
using SafeWeb.PurchaseApprover.Services.Results;
using System.Collections.Generic;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Services.Mappers
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<ValidationResult, ServiceResult>()
                .ForMember(x => x.Errors, opt => opt.ResolveUsing(src =>
                {
                    var errors = new List<string>();
                    src.Errors.ToList().ForEach(x => errors.Add(x.ErrorMessage));
                    return errors;
                }));


        }
    }
}
