using System;
using System.Threading.Tasks;
using DataLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IStoreRepository : IRepository<Store>
    {
        Task<Store> GetStoreWithEmployee(Guid id);      
    }
}
