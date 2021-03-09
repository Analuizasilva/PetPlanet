using System;
using System.Threading.Tasks;
using Data;

namespace DataAccessLayer.DataAccessObject.Interfaces
{
    public interface IPetDataAccessObject : IDataAccessObject<Pet>
    {
        Task<Pet> GetPetWithClient(Guid id);
        Task<Pet> GetPetByClient(Guid clientId);
    }
}
