namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface IClientService
    {
        IQueryable GetAll();

        Client GetById(int id);

        IQueryable GetAllOrders(int id);
    }
}