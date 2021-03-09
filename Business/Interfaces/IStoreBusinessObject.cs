using System;
using System.Threading.Tasks;
using Business.OperationResult;
using Data;

namespace Business.Interfaces
{
    public interface IStoreBusinessObject : IBusinessObject<Store>
    {
        Task<OperationResult<Store>> GetStoreWithEmployee(Guid id);
    }
}
