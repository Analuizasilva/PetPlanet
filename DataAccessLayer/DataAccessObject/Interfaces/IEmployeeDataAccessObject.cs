using System;
using System.Threading.Tasks;
using Data;

namespace DataAccessLayer.DataAccessObject.Interfaces
{
    public interface IEmployeeDataAccessObject : IDataAccessObject<Employee>
    {
        Task<Employee> GetEmployeeByStore(Guid storeId);
        Task<Employee> GetEmployeeWithStore(Guid Id);
    }
}
