using System.Threading.Tasks;
using System;
using DataLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClientByPet(Guid petId);
        Task<Client> GetClientWithPet(Guid id);
    }
}
