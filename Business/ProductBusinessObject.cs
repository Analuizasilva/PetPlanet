using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.OperationResult;
using Data;
using DataAccessLayer.DataAccessObject.Interfaces;

namespace Business
{
    public class ProductBusinessObject : BusinessObject<Product>, IProductBusinessObject
    {
        private readonly IProductDataAccessObject _dao;

        public ProductBusinessObject(IProductDataAccessObject dao) : base(dao)
        {
            _dao = dao;
        }

        public async Task<OperationResult<Product>> GetProductWithService(Guid id)
        {
            try
            {
                var productWithService = await _dao.GetProductWithService(id);
                return new OperationResult<Product>() { Success = true, Result = productWithService };
            }
            catch (Exception e)
            {
                return new OperationResult<Product>() { Success = false, Exception = e };
            }
        }
    }
}
