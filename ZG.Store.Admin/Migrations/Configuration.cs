namespace ZG.Store.Admin.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZG.Store.Admin.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZG.Store.Admin.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ZG.Store.Admin.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // Create 4 test users:
            for (int i = 0; i < 4; i++)
            {
                var user = new ApplicationUser()
                {
                    UserName = string.Format("czhang{0}", i.ToString())
                };
                manager.Create(user, string.Format("Password{0}", i.ToString()));
            }
        }
    }
}
