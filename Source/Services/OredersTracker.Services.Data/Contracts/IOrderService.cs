﻿namespace OredersTracker.Services.Data.Contracts
{
    using System.Linq;

    using OredersTracker.Data.Models;

    public interface IOrderService
    {
        IQueryable<Order> GetAll();

        Order GetById(int id);

        IQueryable<Order> GetCompleted();

        IQueryable<Order> GetUnfinished();

        decimal GetOrdersTotalForMonth(int month);

        IQueryable<Order> GetAllSentByEcont();

        IQueryable<Order> GetAllPaidByCard();

        void Add(Order order);
    }
}