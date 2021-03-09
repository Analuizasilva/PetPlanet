using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.OperationResult;

namespace Business.Interfaces
{
    public interface IBusinessObject<TEntity>
    {
        Task<OperationResult<TEntity>> Create(TEntity entity);
        Task<OperationResult<TEntity>> GetById(Guid id);
        Task<OperationResult<IEnumerable<TEntity>>> Read();
        Task<OperationResult<TEntity>> Delete(Guid id);
        Task<OperationResult<TEntity>> Update(TEntity entity);
    }
}
