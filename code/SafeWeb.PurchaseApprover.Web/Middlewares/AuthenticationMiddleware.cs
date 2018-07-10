using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SafeWeb.PurchaseApprover.Model.Administration;
using System;
using System.Threading.Tasks;

namespace SafeWeb.PurchaseApprover.Web.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate Next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            Next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            await Next.Invoke(context);
            return;

            var serializedUser = context.Session.GetString("LoggedUser");
            User user = null;

            try
            {
                user = JsonConvert.DeserializeObject<User>(serializedUser);
            }
            catch(Exception e) { }


            var privateContext = context.Request.Path.StartsWithSegments("/api", StringComparison.InvariantCultureIgnoreCase) && 
                !context.Request.Path.StartsWithSegments("/api/login", StringComparison.InvariantCultureIgnoreCase);

            if (!privateContext)
            {
                await Next.Invoke(context);
                return;
            }
            else if (privateContext && user == null)
            {
                context.Response.StatusCode = 401;
                return;
            }

            context.Items.Add("LoggedUser", user);
            await Next.Invoke(context);
        }
    }
}
