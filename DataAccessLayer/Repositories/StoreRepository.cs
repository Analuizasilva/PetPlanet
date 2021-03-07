using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(PetPlanetContext context) : base(context)
        {
        }

        public async Task<Store> GetStoreWithEmployee(Guid id)
        {
            return await db.AsNoTracking()
                        .Include(s => s.Employees)
                            .Where(e => e.Employees.Where(s => s.Id == id).Any())
                        .FirstOrDefaultAsync();
        }
    }
}
