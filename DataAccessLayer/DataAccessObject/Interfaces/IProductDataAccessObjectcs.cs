using System;
using System.Threading.Tasks;
using Data;

namespace DataAccessLayer.DataAccessObject.Interfaces
{
    public interface IProductDataAccessObject : IDataAccessObject<Product>
    {      
        Task<Product> GetProductWithService(Guid id);
    }
}
