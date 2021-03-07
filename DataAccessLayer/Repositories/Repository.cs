﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DataLayer.Base;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly PetPlanetContext context;
        protected readonly DbSet<TEntity> db;

        protected Repository(PetPlanetContext context)
        {
            this.context = context;
            this.db = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await db.AddAsync(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await db.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await db.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await db.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
            var entity = await GetById(id);

            db.Remove(entity);

            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            db.Update(entity);
            await SaveChanges();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
