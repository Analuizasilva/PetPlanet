using System;
using System.Threading.Tasks;
using DataLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetEmployeeByStore(Guid storeId);
        Task<Employee> GetEmployeeWithStore(Guid Id);
    }
}
