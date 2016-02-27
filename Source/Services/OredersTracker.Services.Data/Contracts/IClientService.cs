namespace OredersTracker.Services.Data.Contracts
{
    using System.Linq;

    using OredersTracker.Data.Models;

    public interface IClientService
    {
        IQueryable<Client> GetAll();

        Client GetById(int id);

        IQueryable<Order> GetAllOrders(int id);

        void Add(Client model);
    }
}