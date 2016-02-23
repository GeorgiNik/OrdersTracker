namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class ClientService : IClientService
    {
        private IDbRepository<Client> clients;

        private IDbRepository<Order> orders;

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
    }
}