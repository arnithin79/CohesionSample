using Cohesion.Entities;
using Cohesion.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
            return entity.FirstOrDefault(e => e.Id == id);
        }

        public T Create(T data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.Add(data);
            _context.SaveChanges();
            return data;
        }

        public void Update(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException("entity");
            }
            T data = GetById(id);
            if(data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
