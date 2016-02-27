namespace OrdersTracker.Services.Data
{
    using System.Linq;

    using OrdersTracker.Data;
    using OrdersTracker.Services.Data.Contracts;

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