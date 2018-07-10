using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;

namespace SafeWeb.PurchaseApprover.Services.Interfaces
{
    public interface IProposalService : IBaseService<SaveProposalMessage>
    {
        ServiceResult SaveProposalFile(SaveProposalFileMessage message);
    }
}
