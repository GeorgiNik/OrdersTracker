namespace OredersTracker.Services.Data.Contracts
{
    using System.Linq;

    using OredersTracker.Data.Models;

    public interface IUserService
    {
        int GetUsersCount();

        void MakeAdmin(string id);

        void RemoveAdmin(string id);

        void Update(ApplicationUser user);

        void Remove(ApplicationUser user);

        IQueryable<ApplicationUser> All();

    }
}