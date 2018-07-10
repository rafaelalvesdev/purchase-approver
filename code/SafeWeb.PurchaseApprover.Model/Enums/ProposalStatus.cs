using System.ComponentModel.DataAnnotations;
using Safeweb.PurchaseApprover.Common.Attributes;
using SafeWeb.PurchaseApprover.Resources;

namespace SafeWeb.PurchaseApprover.Model.Enums
{
    public enum ProposalStatus
    {
        [Display(ResourceType = typeof(UIResources), Name = "ProposalStatus_Pending")]
        [EntityCanBeModified]
        Pending,

        [Display(ResourceType = typeof(UIResources), Name = "ProposalStatus_PendingCFOApproval")]
        [EntityCanBeModified]
        PendingCFOApproval,

        [Display(ResourceType = typeof(UIResources), Name = "ProposalStatus_Approved")]        
        Approved,

        [Display(ResourceType = typeof(UIResources), Name = "ProposalStatus_Disapproved")]
        Disapproved,
    }
}
