using System;
using System.Threading.Tasks;
using Business.OperationResult;
using Data;

namespace Business.Interfaces
{
    public interface IClientBusinessObject : IBusinessObject<Client>
    {
        Task<OperationResult<Client>> GetClientByPet(Guid petId);
        Task<OperationResult<Client>> GetClientWithPet(Guid id);
    }
}
