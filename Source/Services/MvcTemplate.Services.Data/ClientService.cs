namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class ClientService : IClientService
    {
        private readonly IDbRepository<Client> clients;

        private readonly IDbRepository<Order> orders;

        public ClientService(IDbRepository<Order> orders, IDbRepository<Client> clients)
        {
            this.clients = clients;
            this.orders = orders;
        }

        public IQueryable GetAll()
        {
            return this.clients.All();
        }

        public Client GetById(int id)
        {
            return this.clients.GetById(id);
        }

        public IQueryable GetAllOrders(int id)
        {
            return this.orders.All().Where(x => x.ClientId == id);
        }

        public void Add(Client model)
        {
            this.clients.Add(model);
            this.clients.Save();
        }
    }
}