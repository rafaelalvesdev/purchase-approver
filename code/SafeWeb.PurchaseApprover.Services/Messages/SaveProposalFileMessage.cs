using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWeb.PurchaseApprover.Services.Messages
{
    public class SaveProposalFileMessage
    {
        public int ProposalID { get; set; }
        public string FilePath { get; set; }
    }
}
