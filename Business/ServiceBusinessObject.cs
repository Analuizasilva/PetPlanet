using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.OperationResult;
using Data;
using DataAccessLayer.DataAccessObject.Interfaces;

namespace Business
{
    public class ServiceBusinessObject : BusinessObject<Service>, IServiceBusinessObject
    {
        private readonly IServiceDataAccessObject _dao;

        public ServiceBusinessObject(IServiceDataAccessObject serviceDataAccessObject) : base(serviceDataAccessObject)
        {
            this._dao = serviceDataAccessObject;
        }
        public async Task<OperationResult<Service>> GetServiceWithProduct(Guid productId)
        {
            try
            {
                var serviceWithProduct = await _dao.GetServiceWithProduct(productId);
                return new OperationResult<Service>() { Success = true, Result = serviceWithProduct };
            }
            catch (Exception e)
            {
                return new OperationResult<Service>() { Success = false, Exception = e };
            }
        }
    }
}
