using Cohesion.Entities;
using Cohesion.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public IQueryable<T> GetAll()
        {
            return entity.AsQueryable();
        }

        public T GetById(Guid id)
        {
            return entity.FirstOrDefault();
        }
    }
}
