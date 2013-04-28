﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain;

namespace ZG.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> FindAll();
        T FindById(int id);
        void Add(T newEntity);
        void Remove(T entity);
    }

    public class ZGStoreRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbSet<T> _dbSet;

        public ZGStoreRepository(ZGStoreContext context)
        {
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return _dbSet;
        }

        public virtual T FindById(int id)
        {
            return _dbSet.SingleOrDefault(o => o.Id == id);
        }

        public void Add(T newEntity)
        {
            _dbSet.Add(newEntity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        protected IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
