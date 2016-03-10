namespace OredersTracker.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using OredersTracker.Common;
    using OredersTracker.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //var randomGen = new Random();
            //const string AdministratorUserName = "admin@admin.com";
            //const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                //// Create admin user
                //var userStore = new UserStore<ApplicationUser>(context);
                //var userManager = new UserManager<ApplicationUser>(userStore);
                //var admin = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                //userManager.Create(admin, AdministratorPassword);
                //context.SaveChanges();

                //// Assign user to admin role
                //userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);

                //var client = new Client { EIK = "999999999", Name = "Client" };

                //var orders = new List<Order>();

                //for (var i = 1; i <= 10; i++)
                //{
                //    var order = new Order
                //    {
                //        Description = $"Order {i}",
                //        OrderPrice = i * i * i,
                //        DateOfComplition = DateTime.UtcNow.AddDays(30),
                //        Client = client
                //    };
                //    orders.Add(order);
                //    context.Orders.Add(order);
                //}
                context.SaveChanges();
            }
        }
    }
}