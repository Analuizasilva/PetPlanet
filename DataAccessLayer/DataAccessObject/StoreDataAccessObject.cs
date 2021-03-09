using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataAccessObject
{
    public class StoreDataAccessObject : DataAccessObject<Store>, IStoreDataAccessObject
    {
        public StoreDataAccessObject(PetPlanetContext context) : base(context)
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
