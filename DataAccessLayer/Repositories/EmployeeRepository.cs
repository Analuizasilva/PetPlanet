using System;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PetPlanetContext context) : base(context)
        {
        }

        public async Task<Employee> GetEmployeeByStore(Guid storeId)
        {
            return await db.AsNoTracking()
                         .Include(e => e.Store)
                         .FirstOrDefaultAsync(e => e.StoreId == storeId);
        }

        public async Task<Employee> GetEmployeeWithStore(Guid id)
        {
            return await db.AsNoTracking()
                        .Include(e => e.Store)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
