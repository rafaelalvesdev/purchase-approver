using SafeWeb.PurchaseApprover.Infrastructure;
using SafeWeb.PurchaseApprover.Model.Administration;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SafeWeb.PurchaseApprover.Services.Configurations
{
    public abstract class AbstractConfigurator
    {
        private PurchaseApproverDbContext DbContext { get; set; }
        private Dictionary<string, string> Configurations { get; set; }
        private List<PropertyInfo> MyProperties { get; } = typeof(AbstractConfigurator).GetProperties(BindingFlags.Public).ToList();

        public AbstractConfigurator(PurchaseApproverDbContext dbContext)
        {
            DbContext = dbContext;
            LoadConfigurations();
        }

        private void LoadConfigurations()
        {
            this.Configurations = DbContext.Set<Configuration>().AsQueryable()
                .ToDictionary(x => x.Name, x => x.Value);

            MyProperties.ForEach(x =>
            {
                if (Configurations.ContainsKey(x.Name))
                    x.SetValue(this, Configurations[x.Name]);
            });
        }

        public void SaveConfigurations()
        {
            var Keys = MyProperties.Select(x => x.Name).ToList();
            var CurrentConfigs = DbContext.Set<Configuration>().Where(x => Keys.Contains(x.Name)).ToList();

            CurrentConfigs.ForEach(c =>
            {
                var prop = MyProperties.FirstOrDefault(x => x.Name == c.Name);
                if (prop != null)
                    c.Value = prop.GetValue(this) as string;
            });

            DbContext.SaveChanges();
        }
    }
}
