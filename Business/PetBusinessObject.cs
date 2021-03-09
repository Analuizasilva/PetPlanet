using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.OperationResult;
using Data;
using DataAccessLayer.DataAccessObject.Interfaces;

namespace Business
{
    public class PetBusinessObject : BusinessObject<Pet>, IPetBusinessObject
    {
        private readonly IPetDataAccessObject _dao;

        public PetBusinessObject(IPetDataAccessObject petDataAccessObject) : base(petDataAccessObject)
        {
            this._dao = petDataAccessObject;
        }

        public async Task<OperationResult<Pet>> GetPetByClient(Guid clientId)
        {
            try
            {
                var petByClient = await _dao.GetPetByClient(clientId);
                return new OperationResult<Pet>() { Success = true, Result = petByClient };
            }
            catch (Exception e)
            {
                return new OperationResult<Pet>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Pet>> GetPetWithClient(Guid id)
        {
            try
            {
                var petWithClient = await _dao.GetPetWithClient(id);
                return new OperationResult<Pet>() { Success = true, Result = petWithClient };
            }
            catch (Exception e)
            {
                return new OperationResult<Pet>() { Success = false, Exception = e };
            }
        }
    }
}
