using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Services.Extensions;
using System;
using System.Threading.Tasks;

namespace SafeWeb.PurchaseApprover.Web.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate Next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            Next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception e)
            {
                var body = JsonConvert.SerializeObject(false.AsServiceResultWithEntity().WithMessage(e.Message));
                context.Response.Clear();
                context.Response.WriteAsync(body);
                context.Response.StatusCode = 500;
            }
        }
    }
}
