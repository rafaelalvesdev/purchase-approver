using SafeWeb.PurchaseApprover.Services.Results;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Services.Extensions
{
    public static class ServiceResultExtension
    {
        public static ServiceResult AsServiceResultWithID<T>(this T Data)
        {
            var sr = new ServiceResult();

            if (Data == null)
                return sr;

            var type = typeof(T);
            var keyProperty = type.GetProperties().ToList().FirstOrDefault(x => x.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0);
            if (keyProperty == null)
                return sr;

            var value = keyProperty.GetValue(Data);
            return new ServiceResult()
            {
                EntityKey = value.ToString()
            };
        }

        public static ServiceResult AsServiceResultWithEntity<T>(this T Data)
        {
            return new ServiceResult<T>()
            {
                Data = Data
            };
        }

        public static ServiceResult SetValid(this ServiceResult serviceResult)
        {
            serviceResult.IsValid = true;
            return serviceResult;
        }

        public static ServiceResult SetInvalid(this ServiceResult serviceResult)
        {
            serviceResult.IsValid = false;
            return serviceResult;
        }

        public static ServiceResult WithMessage(this ServiceResult serviceResult, string message)
        {
            serviceResult.Errors.Add(message);
            return serviceResult;
        }
    }
}
