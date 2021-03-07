using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    interface IServiceRepository : IRepository<Service>
    {
        Task<Service> GetServiceWithProduct(Guid productId);
    }
}
