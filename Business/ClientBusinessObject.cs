using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.OperationResult;
using DataAccessLayer.DataAccessObject.Interfaces;
using Data;

namespace Business
{
    public class ClientBusinessObject : BusinessObject<Pet>, IClientBusinessObject
    {
        private readonly IClientDataAccessObject _dao;

        public ClientBusinessObject(IClientDataAccessObject clientDataAccessObject) : base(clientDataAccessObject)
        {
            this._dao = clientDataAccessObject;
        }

        public async Task<OperationResult<Pet>> GetClientByPet(Guid petId)
        {
            try
            {
                var clientByPet = await _dao.GetClientByPet(petId);
                return new OperationResult<Pet>() { Success = true, Result = clientByPet };
            }
            catch (Exception e)
            {
                return new OperationResult<Pet>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Pet>> GetClientWithPet(Guid id)
        {
            try
            {
                var clientWithPet = await _dao.GetClientWithPet(id);
                return new OperationResult<Pet>() { Success = true, Result = clientWithPet };
            }
            catch (Exception e)
            {
                return new OperationResult<Pet>() { Success = false, Exception = e };
            }
        }
    }
}
