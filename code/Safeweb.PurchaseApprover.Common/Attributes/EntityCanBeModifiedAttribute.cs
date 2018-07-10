using System;
using System.Linq;
using System.Reflection;

namespace Safeweb.PurchaseApprover.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityCanBeModified : Attribute    {

        public static bool CheckIfEntityCanBeModified<T>(T checkProperty)
        {
            var field = typeof(T).GetField(checkProperty.ToString());
            return field.IsDefined(typeof(T), false);
        }

    }
}
