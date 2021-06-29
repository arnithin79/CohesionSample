using System;
using System.Linq;

namespace Cohesion.Services.Repositories.BaseRepository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T GetById(Guid id);

        T Create(T data);

        void Update(T data);
    }
}
