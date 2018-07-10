using Microsoft.EntityFrameworkCore;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeWeb.PurchaseApprover.Infrastructure
{
    public class DbDataSeeder
    {
        public static void Seed(DbContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    SeedConfigurations(context);
                    SeedUserProfiles(context);
                    SeedUsers(context);

                    transaction.Commit();
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }

        private static void SeedConfigurations(DbContext context)
        {
            if (!context.Set<Configuration>().Any(x => x.Name.Equals("PurchaseProposal_HoursToExpire")))
                context.Set<Configuration>().Add(new Configuration()
                {
                    Name = "PurchaseProposal_HoursToExpire",
                    Value = "24"
                });
            context.SaveChanges();
        }

        private static void SeedUsers(DbContext context)
        {

            if (!context.Set<User>().Any(x => x.ID == 1))
                context.Add(new User()
                {
                    Name = "Administrador",
                    BirthDate = DateTime.MinValue,
                    DocumentNumber = string.Empty,
                    UserProfile = context.Set<UserProfile>().First(x => x.ID == 1)
                });
            context.SaveChanges();

        }

        private static void SeedUserProfiles(DbContext context)
        {
            // Untrack
            var allSystemRoles = new List<SystemRoles>();
            foreach (SystemRoles sr in Enum.GetValues(typeof(SystemRoles))) allSystemRoles.Add(sr);
            var profileRoles = allSystemRoles.Select(x => (ProfileRole)x).AsQueryable();

            if (!context.Set<UserProfile>().Any(x => x.ID == 1))
                context.Add(new UserProfile()
                {
                    Name = "Administrador",
                    ProfileRoles = profileRoles.AsNoTracking().ToList()
        });

            //profileRoles.AsQueryable().AsNoTracking();

            if (!context.Set<UserProfile>().Any(x => x.ID == 2))
                context.Add(new UserProfile()
                {
                    Name = "Analista de Compras",
                    ProfileRoles = profileRoles.AsNoTracking()
                        .Where(x => !x.Role.ToString().StartsWith("User_"))
                        .Where(x => !x.Role.ToString().StartsWith("Proposal_Approve"))
                        .ToList()
        });

            if (!context.Set<UserProfile>().Any(x => x.ID == 3))
                context.Add(new UserProfile()
                {
                    Name = "Analista Financeiro",
                    ProfileRoles = profileRoles.AsNoTracking()
                        .Where(x => !x.Role.ToString().StartsWith("User_"))
                        .ToList()
        });

            if (!context.Set<UserProfile>().Any(x => x.ID == 4))
                context.Add(new UserProfile()
                {
                    Name = "Diretor Financeiro",
                    ProfileRoles = profileRoles.AsNoTracking()
                        .Where(x => !x.Role.ToString().StartsWith("User_"))
                        .ToList()
        });
            context.SaveChanges();

        }
    }
}
