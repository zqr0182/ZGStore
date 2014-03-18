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
            this.AddUserAndRoles();
        }

        bool AddUserAndRoles()
        {
            bool success = false;
  
            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;
  
            success = idManager.CreateRole("CanEdit");
            if (!success == true) return success;
  
            success = idManager.CreateRole("User");
            if (!success) return success;
  
  
            var newUser = new ApplicationUser()
            {
                UserName = "czhang",
                FirstName = "Charles",
                LastName = "Zhang",
                Email = "zhangxiao1234@hotmail.com"
            };
  
            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Abc123456!");
            if (!success) return success;
  
            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;
  
            success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;
  
            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;
  
            return success;
        }
    }
}
