using Infra.Context;
using Infra.Entities;

namespace Infra.Repositories.Interfaces
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly CourseDbContext _context;
        
        public CourseRepository(CourseDbContext context) 
            : base(context)
        {
            _context = context;
        }

    }
}