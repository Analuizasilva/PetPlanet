using System;
using System.Threading.Tasks;
using Business.OperationResult;
using Data;

namespace Business.Interfaces
{
    public interface IClientBusinessObject : IBusinessObject<Pet>
    {
        Task<OperationResult<Pet>> GetClientByPet(Guid petId);
        Task<OperationResult<Pet>> GetClientWithPet(Guid id);
    }
}
