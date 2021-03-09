using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.OperationResult;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data.Base;

namespace Business
{
    public abstract class BusinessObject<TEntity> : IBusinessObject<TEntity> where TEntity : Entity
    {
        private readonly IDataAccessObject<TEntity> _dao;

        protected BusinessObject(IDataAccessObject<TEntity> dataAccessObject)
        {
            this._dao = dataAccessObject;
        }

        #region Create
        public async Task<OperationResult<TEntity>> Create(TEntity entity)
        {
            try
            {
                await _dao.Create(entity);

                return new OperationResult<TEntity>() { Success = true, Result = entity };
            }
            catch (Exception e)
            {
                return new OperationResult<TEntity>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public async Task<OperationResult<IEnumerable<TEntity>>> Read()
        {
            try
            {
                var result = await _dao.Read();
                return new OperationResult<IEnumerable<TEntity>>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<IEnumerable<TEntity>>() { Success = false, Exception = e };
            }
        }

        #endregion

        #region Update
        public async Task<OperationResult<TEntity>> Update(TEntity entity)
        {
            try
            {
                await _dao.Update(entity);
                return new OperationResult<TEntity>() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<TEntity>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public async Task<OperationResult<TEntity>> Delete(Guid id)
        {
            try
            {
                await _dao.Delete(id);
                return new OperationResult<TEntity>() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<TEntity>() { Success = false, Exception = e };
            }
        }
        #endregion 

        #region GetById
        public async Task<OperationResult<TEntity>> GetById(Guid id)
        {
            try
            {
                var result = await _dao.GetById(id);
                return new OperationResult<TEntity>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<TEntity>() { Success = false, Exception = e };
            }
        }

        #endregion

    }
}
