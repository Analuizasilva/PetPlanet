using System;
using System.Threading.Tasks;
using Business.OperationResult;
using Data;

namespace Business.Interfaces
{
    public interface IServiceBusinessObject : IBusinessObject<Service>
    {
        Task<OperationResult<Service>> GetServiceWithProduct(Guid productId);
    }
}
