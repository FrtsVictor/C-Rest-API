using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Entities;
using UserManager.Infra.Context;
using UserManager.Infra.Interfaces;

namespace UserManager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly UserManagerContext _context;
        

        public BaseRepository(UserManagerContext context)
        {
            _context  = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            //context ja cria e retorna a entidade com id, retornar ela no obj
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Remove(long id)
        {
            var obj = await Get(id);

            if(obj != null){
                _context.Remove(obj); //evitar tacar exception
                await _context.SaveChangesAsync();
            }
            
            return null;
        }

        public virtual async Task<T> Get(long id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking() //pra nao traquear o get e ficar mais rapido, pq get n modifica n precisa de track
                                    .Where(x=>x.Id == id) //monta query ehre id
                                    .ToListAsync(); //quando da o get no banco

            return obj.FirstOrDefault();//pra n devolver uma lista e sim um unico obj
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

    }
        
}
