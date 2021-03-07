using System;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        public PetRepository(PetPlanetContext context) : base(context)
        {
        }

        public async Task<Pet> GetPetByClient(Guid clientId)
        {
            return await db.AsNoTracking()
                           .Include(p => p.Client)
                           .FirstOrDefaultAsync(p => p.ClientId == clientId);
        }

        public async Task<Pet> GetPetWithClient(Guid id)
        {
            return await db.AsNoTracking()
                         .Include(p => p.Client)
                         .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
