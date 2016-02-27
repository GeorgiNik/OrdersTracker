namespace OredersTracker.Services.Data.Contracts
{
    using System.Linq;

    using OredersTracker.Data.Models;

    public interface IOrderService
    {
        IQueryable<Order> All();

        Order GetById(int id);

        decimal GetOrdersTotalForMonth(int month);

        IQueryable<Order> GetAllSentByEcont();

        IQueryable<Order> GetAllPaidByCard();

        void Add(Order order);

        void Update(Order order);

        void Delete(Order order);

    }
}