namespace OredersTracker.Services.Data
{
    using System.Linq;

    using OredersTracker.Data;
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
    }
}