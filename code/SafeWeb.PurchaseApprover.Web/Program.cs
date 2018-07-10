using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;

namespace SafeWeb.PurchaseApprover.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
