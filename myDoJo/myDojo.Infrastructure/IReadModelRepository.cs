﻿using System;
using System.Collections.Generic;

namespace myDojo.Infrastructure
{
    public interface IReadModelRepository<T> where T : IObjectWithIdentity,new()
    {
        void Store(T entity);
        IEnumerable<T> Get(Predicate<T> query);
        T GetSingle(Predicate<T> query);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        T GetOrCreate(Guid id);
        T Change(Guid id, Action<T> doThis);
        void Delete(T item);
    }
}