namespace OredersTracker.Services.Data
{
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.InteropServices;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using OredersTracker.Common;
    using OredersTracker.Data;
    using OredersTracker.Data.Models;
    using OredersTracker.Services.Data.Contracts;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService()
        {
            this.context = new ApplicationDbContext();
        }

        public int GetUsersCount()
        {
            return this.context.Users.Count();
        }

        public void RemoveAdmin(string id)
        {
            var userStore = new UserStore<ApplicationUser>(this.context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var admin = this.context.Users.FirstOrDefault(x => x.Id == id);

            // Assign user to admin role
            if (admin != null)
            {
                userManager.RemoveFromRole(admin.Id, GlobalConstants.AdministratorRoleName);
            }
            this.context.SaveChanges();
        }
        public void MakeAdmin(string id)
        {
            var userStore = new UserStore<ApplicationUser>(this.context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var admin = this.context.Users.FirstOrDefault(x => x.Id == id);

            // Assign user to admin role
            if (admin != null)
            {
                userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);
            }
            this.context.SaveChanges();
        }

        public IQueryable<ApplicationUser> All()
        {
            return this.context.Users.AsQueryable();
        }
        public void Remove(ApplicationUser user)
        {
            this.context.Users.Attach(user);
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }

        public void Update(ApplicationUser user)
        {
            var entity = this.context.Users.FirstOrDefault(x => x.Id == user.Id);

            if (entity != null)
            {
                entity.AuthorName = user.AuthorName;
                entity.Email = user.Email;
                entity.UserName = user.UserName;
            }

            this.context.Users.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}