using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(PetPlanetContext context) : base(context)
        {
        }

        public async Task<Service> GetServiceWithProduct(Guid productId)
        {
            return await db.AsNoTracking()
                         .Include(c => c.Products)
                         .Where(c => c.Products.Where(p => p.Id == productId).Any())
                         .FirstOrDefaultAsync();
        }
    }
}
