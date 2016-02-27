namespace OredersTracker.Services.Data
{
    using System.Linq;

    using OredersTracker.Data.Common;
    using OredersTracker.Data.Models;
    using OredersTracker.Services.Data.Contracts;

    public class ClientService : IClientService
    {
        private readonly IDbRepository<Client> clients;

        private readonly IDbRepository<Order> orders;

        public ClientService(IDbRepository<Order> orders, IDbRepository<Client> clients)
        {
            this.clients = clients;
            this.orders = orders;
        }

        public IQueryable<Client> All()
        {
            return this.clients.All().AsQueryable();
        }

        public Client GetById(int id)
        {
            return this.clients.GetById(id);
        }

        public IQueryable<Order> GetAllOrders(int id)
        {
            return this.orders.All().Where(x => x.ClientId == id);
        }

        public void Add(Client model)
        {
            this.clients.Add(model);
            this.clients.Save();
        }
        
        public void Delete(Client client)
        {
            this.clients.Delete(client.Id);
            this.clients.Save();
        }
        public void Update(Client client)
        {
            var entity = this.clients.GetById(client.Id);

            entity.EIK = client.EIK;
            entity.Name = client.Name;
            entity.Address = client.Address;

            this.clients.Update(entity);
            this.clients.Save();
        }
    }
}