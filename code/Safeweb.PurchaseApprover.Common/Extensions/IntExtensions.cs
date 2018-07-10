namespace Safeweb.PurchaseApprover.Common.Extensions
{
    public static class IntExtensions
    {
        public static bool HasValidIdValue(this int value)
        {
            return value > 0;
        }
    }
}
