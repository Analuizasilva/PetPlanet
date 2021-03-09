using System.Threading.Tasks;
using System;
using Data;

namespace DataAccessLayer.DataAccessObject.Interfaces
{
    public interface IClientDataAccessObject : IDataAccessObject<Pet>
    {
        Task<Pet> GetClientByPet(Guid petId);
        Task<Pet> GetClientWithPet(Guid id);
    }
}
