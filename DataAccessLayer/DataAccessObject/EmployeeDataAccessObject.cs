using System;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataAccessObject
{
    public class EmployeeDataAccessObject : DataAccessObject<Employee>, IEmployeeDataAccessObject
    {
        public EmployeeDataAccessObject(PetPlanetContext context) : base(context)
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
