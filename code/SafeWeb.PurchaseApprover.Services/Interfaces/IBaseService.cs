using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWeb.PurchaseApprover.Services.Interfaces
{
    public interface IBaseService<TSaveMessage>
    {
        ServiceResult Save(TSaveMessage message);
        ServiceResult Get(int id);
        ServiceResult Delete(int id);
    }
}
