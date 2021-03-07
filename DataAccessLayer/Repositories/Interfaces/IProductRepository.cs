using System;
using System.Threading.Tasks;
using DataLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {      
        Task<Product> GetSProductWithService(Guid id);
    }
}
