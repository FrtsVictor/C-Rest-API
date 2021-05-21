using Infra.Context;
using Infra.Entities;

namespace Infra.Repositories.Interfaces
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly CourseDbContext _context;
        
        public UserRepository(CourseDbContext context) 
            : base(context)
        {
            _context = context;
        }

    }
}