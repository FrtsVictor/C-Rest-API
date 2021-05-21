using System.Collections.Generic;
using System.Threading.Tasks;
using Infra.Entities;

namespace Infra.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
         Task<T> Create(T obj);
         Task<T> Update(T obj);
         Task<T> Remove(long id);
         Task<List<T>> Get();
    }
}