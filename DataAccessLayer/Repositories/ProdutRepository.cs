using System;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ProdutRepository : Repository<Product>, IProductRepository
    {
        public ProdutRepository(PetPlanetContext context) : base(context)
        {
        }

        public async Task<Product> GetSProductWithService(Guid id)
        {
            return await db.AsNoTracking()
                     .Include(p => p.Service)
                     .FirstOrDefaultAsync(p => p.Id == id);
        }   
    }
}
