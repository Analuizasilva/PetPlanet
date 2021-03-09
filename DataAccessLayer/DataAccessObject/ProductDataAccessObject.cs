using System;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataAccessObject
{
    public class ProductDataAccessObject : DataAccessObject<Product>, IProductDataAccessObject
    {
        public ProductDataAccessObject(PetPlanetContext context) : base(context)
        {
        }

        public async Task<Product> GetProductWithService(Guid id)
        {
            return await db.AsNoTracking()
                     .Include(p => p.Service)
                     .FirstOrDefaultAsync(p => p.Id == id);
        }   
    }
}
