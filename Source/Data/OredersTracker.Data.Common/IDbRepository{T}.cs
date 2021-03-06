﻿namespace OredersTracker.Data.Common
{
    using System.Linq;

    using OredersTracker.Data.Common.Models;

    public interface IDbRepository<T> : IDbRepository<T, int>
        where T : BaseModel<int>
    {
    }

    public interface IDbRepository<T, in TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void Delete(int id);

        void HardDelete(T entity);

        void Update(T entity);

        void Save();

        void Detach(T entity);

        void Dispose();
    }
}