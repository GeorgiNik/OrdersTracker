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

        public IQueryable<Order> All()
        {
            return this.orders.All();
        }

        public Order GetById(int id)
        {
            return this.orders.GetById(id);
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

        public void Update(Order order)
        {
            var entity = this.orders.GetById(order.Id);

            entity.Deadline = order.Deadline;
            entity.Description = order.Description;
            entity.OrderPrice = order.OrderPrice;
            entity.PaidInAdvance = order.PaidInAdvance;
            entity.BillInCash = order.BillInCash;
            entity.Receipt = order.Receipt;
            entity.PaidWithCard = order.PaidWithCard;
            entity.Econt = order.Econt;
            entity.PaidInCashWithoutReceipt = order.PaidInCashWithoutReceipt;
            entity.PaidBankTransaction = order.PaidBankTransaction;
            entity.LeftToBePaid = order.LeftToBePaid;
            entity.PaidAt = order.PaidAt;
            entity.DateOfComplition = order.DateOfComplition;
            entity.Bonuses = order.Bonuses;
            entity.IsComplited = order.IsComplited;

            this.orders.Update(entity);
            this.orders.Save();
        }

        public void Delete(Order order)
        {
            this.orders.Delete(order.Id);
            this.orders.Save();
        }
    }
}