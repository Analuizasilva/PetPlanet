using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.OperationResult;
using Data;
using DataAccessLayer.DataAccessObject.Interfaces;

namespace Business
{
    public class StoreBusinessObject : BusinessObject<Store>, IStoreBusinessObject
    {
        private readonly IStoreDataAccessObject _dao;

        public StoreBusinessObject(IStoreDataAccessObject storeDataAccessObject) : base(storeDataAccessObject)
        {
            this._dao = storeDataAccessObject;
        }

        public async Task<OperationResult<Store>> GetStoreWithEmployee(Guid id)
        {
            try
            {
                var storeWithEmployee = await _dao.GetStoreWithEmployee(id);
                return new OperationResult<Store>() { Success = true, Result = storeWithEmployee };
            }
            catch (Exception e)
            {
                return new OperationResult<Store>() { Success = false, Exception = e };
            }
        }
    }
}
