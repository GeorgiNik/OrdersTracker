namespace OredersTracker.Services.Data
{
    using System.Linq;

    using OredersTracker.Data.Common;
    using OredersTracker.Data.Models;
    using OredersTracker.Services.Data.Contracts;

    public class OrderService : IOrderService
    {
        private readonly IDbRepository<Order> orders;

        public OrderService(IDbRepository<Order> orders)
        {
            this.orders = orders;
        }

        public IQueryable<Order> GetAll()
        {
            return this.orders.All();
        }

        public Order GetById(int id)
        {
            return this.orders.GetById(id);
        }

        public IQueryable<Order> GetCompleted()
        {
            return this.orders.All().Where(x => x.IsComplited);
        }

        public IQueryable<Order> GetUnfinished()
        {
            return this.orders.All().Where(x => x.IsComplited == false);
        }

        public decimal GetOrdersTotalForMonth(int month)
        {
            return this.orders.All().Where(x => x.CreatedOn.Month == month).Sum(sum => sum.OrderPrice);
        }

        public IQueryable<Order> GetAllSentByEcont()
        {
            return this.orders.All().Where(x => x.Econt != 0);
        }

        public IQueryable<Order> GetAllPaidByCard()
        {
            return this.orders.All().Where(x => x.PaidWithCard != 0);
        }

        public void Add(Order order)
        {
            this.orders.Add(order);
            this.orders.Save();
        }
    }
}