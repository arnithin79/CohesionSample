using Cohesion.Entities;
using Cohesion.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cohesion.Services.Repositories.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private CohesionDBContext _context;
        private DbSet<T> entity;

        public Repository(CohesionDBContext context)
        {
            _context = context;
            entity = _context.Set<T>();
        }

    }
}
