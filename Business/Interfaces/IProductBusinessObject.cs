using System;
using System.Threading.Tasks;
using Business.OperationResult;
using Data;

namespace Business.Interfaces
{
    public interface IProductBusinessObject : IBusinessObject<Product>
    {
        Task<OperationResult<Product>> GetProductWithService(Guid id);
    }
}
