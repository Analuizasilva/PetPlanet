using System;
using System.Threading.Tasks;
using Data;

namespace DataAccessLayer.DataAccessObject.Interfaces
{
    public interface IStoreDataAccessObject : IDataAccessObject<Store>
    {
        Task<Store> GetStoreWithEmployee(Guid id);      
    }
}
