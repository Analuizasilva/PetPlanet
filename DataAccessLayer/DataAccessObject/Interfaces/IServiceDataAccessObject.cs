using System;
using System.Threading.Tasks;
using Data;

namespace DataAccessLayer.DataAccessObject.Interfaces
{
    public interface IServiceDataAccessObject : IDataAccessObject<Service>
    {
        Task<Service> GetServiceWithProduct(Guid productId);
    }
}
