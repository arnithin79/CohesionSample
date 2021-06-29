using Cohesion.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cohesion.Entities
{
    public class CohesionDBContext : DbContext
    {
        public CohesionDBContext(DbContextOptions<CohesionDBContext> options) : base(options)
        {

        }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
