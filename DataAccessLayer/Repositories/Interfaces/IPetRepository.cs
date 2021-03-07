using System;
using System.Threading.Tasks;
using DataLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IPetRepository : IRepository<Pet>
    {
        Task<Pet> GetPetWithClient(Guid id);
        Task<Pet> GetPetByClient(Guid clientId);
    }
}
