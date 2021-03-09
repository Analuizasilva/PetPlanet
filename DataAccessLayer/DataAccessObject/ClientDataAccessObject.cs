﻿using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataAccessObject
{
    public class ClientDataAccessObject : DataAccessObject<Pet>, IClientDataAccessObject
    {
        public ClientDataAccessObject(PetPlanetContext context) : base(context)
        {
        }

        public async Task<Pet> GetClientByPet(Guid petId)
        {
            return await db.AsNoTracking()
                         .Include(c => c.Pets)
                         .Where(c => c.Pets.Where(p => p.Id == petId).Any())
                         .FirstOrDefaultAsync();
        }

        public async Task<Pet> GetClientWithPet(Guid id)
        {
            return await db.AsNoTracking()
                          .Include(c => c.Pets)
                          .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
