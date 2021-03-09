using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataAccessObject
{
    public class ServiceDataAccessObject : DataAccessObject<Service>, IServiceDataAccessObject
    {
        public ServiceDataAccessObject(PetPlanetContext context) : base(context)
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
