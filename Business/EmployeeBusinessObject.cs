using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.OperationResult;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data;

namespace Business
{
    public class EmployeeBusinessObject : BusinessObject<Employee>, IEmployeeBusinessObject
    {
        private readonly IEmployeeDataAccessObject _dao;

        public EmployeeBusinessObject(IEmployeeDataAccessObject employeeDataAccessObject) : base(employeeDataAccessObject)
        {
            this._dao = employeeDataAccessObject;
        }
        public async Task<OperationResult<Employee>> GetEmployeeByStore(Guid storeId)
        {
            try
            {
                var employeeByStore = await _dao.GetEmployeeByStore(storeId);
                return new OperationResult<Employee>() { Success = true, Result = employeeByStore };
            }
            catch (Exception e)
            {
                return new OperationResult<Employee>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Employee>> GetEmployeeWithStore(Guid id)
        {
            try
            {
                var employeeWithStore = await _dao.GetEmployeeWithStore(id);
                return new OperationResult<Employee>() { Success = true, Result = employeeWithStore };
            }
            catch (Exception e)
            {
                return new OperationResult<Employee>() { Success = false, Exception = e };
            }
        }
    }
}
