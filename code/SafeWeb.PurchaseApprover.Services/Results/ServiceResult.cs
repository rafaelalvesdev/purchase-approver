using System.Collections.Generic;

namespace SafeWeb.PurchaseApprover.Services.Results
{
    public class ServiceResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public object EntityKey { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}
