using System.Threading.Tasks;
using System;
using Data;

namespace DataAccessLayer.DataAccessObject.Interfaces
{
    public interface IClientDataAccessObject : IDataAccessObject<Client>
    {
        Task<Client> GetClientByPet(Guid petId);
        Task<Client> GetClientWithPet(Guid id);
    }
}
