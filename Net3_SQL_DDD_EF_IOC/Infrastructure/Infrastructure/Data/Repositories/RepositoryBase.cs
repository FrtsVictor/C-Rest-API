using System;
using System.Collections.Generic;
using System.Linq;
using Domain.API.Core.Interfaces.Repositories;
using Infrastructure.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.API.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                sqlContext.Set<TEntity>().Add(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return sqlContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return sqlContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            try
            {
                sqlContext.Set<TEntity>().Remove(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                sqlContext.Entry(obj).State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}