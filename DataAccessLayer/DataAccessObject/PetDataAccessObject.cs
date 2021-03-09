using System;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataAccessObject
{
    public class PetDataAccessObject : DataAccessObject<Pet>, IPetDataAccessObject
    {
        public PetDataAccessObject(PetPlanetContext context) : base(context)
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
