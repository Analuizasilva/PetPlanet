using System;
using System.Threading.Tasks;
using Business.OperationResult;
using Data;

namespace Business.Interfaces
{
    public interface IPetBusinessObject : IBusinessObject<Pet>
    {
        Task<OperationResult<Pet>> GetPetWithClient(Guid id);
        Task<OperationResult<Pet>> GetPetByClient(Guid clientId);
    }
}
