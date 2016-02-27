namespace OrdersTracker.Services.Data.Contracts
{
    using System.Linq;

    using OrdersTracker.Data.Models;

    public interface IClientService
    {
        IQueryable<Client> GetAll();

        Client GetById(int id);

        IQueryable<Order> GetAllOrders(int id);

        void Add(Client model);
    }
}