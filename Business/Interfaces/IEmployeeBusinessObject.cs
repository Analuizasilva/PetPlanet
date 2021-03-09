using System.Threading.Tasks;
using System;
using Data;
using Business.OperationResult;

namespace Business.Interfaces
{
    public interface IEmployeeBusinessObject : IBusinessObject<Employee>
    {
        Task<OperationResult<Employee>> GetEmployeeByStore(Guid storeId);
        Task<OperationResult<Employee>> GetEmployeeWithStore(Guid id);
    }
}
