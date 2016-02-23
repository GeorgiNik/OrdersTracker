namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface IOrderService
    {
        IQueryable GetAll();

        Order GetById(int id);

        IQueryable GetCompleted();

        IQueryable GetUnfinished();

        decimal GetOrdersTotalForMonth(int month);

        IQueryable GetAllSentByEcont();

        IQueryable GetAllPaidByCard();

        void Add(Order order);
    }
}