using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;

namespace SafeWeb.PurchaseApprover.Services.Interfaces
{
    public interface IUserService : IBaseService<SaveUserMessage>
    {
        ServiceResult GetUserByUsernameAndPassword(string username, string password);
    }
}
