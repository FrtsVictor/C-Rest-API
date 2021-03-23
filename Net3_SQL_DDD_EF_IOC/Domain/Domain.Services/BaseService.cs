using System.Collections.Generic;
using Domain.API.Core.Interfaces.Repositories;
using Domain.API.Core.Interfaces.Services;

namespace Domain.API.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> repository;

        public BaseService(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}