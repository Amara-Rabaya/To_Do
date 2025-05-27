using DAL.Interface;
using DAL.ModelsNew;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tranning_pro.BLInterface;

namespace Tranning_pro.BL
{
    public class CitizenBLService : ICitizenBLService
    {
        private readonly IcitizenRebositoryDAL _citizenRepo;

        public CitizenBLService(IcitizenRebositoryDAL citizenRepo)
        {
            _citizenRepo = citizenRepo;
        }

        public async Task<List<Citizen>> GetAllCitizensAsync()
        {
            return await _citizenRepo.GetAllAsync();
        }

        public async Task<Citizen> GetCitizenByIdAsync(int id)
        {
            return await _citizenRepo.GetByIdAsync(id);
        }

        public async Task<bool> AddCitizenAsync(Citizen citizen)
        {
            try
            {
                await _citizenRepo.AddAsync(citizen);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCitizenAsync(int id, Citizen citizen)
        {
            try
            {
                await _citizenRepo.UpdateAsync(id, citizen);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCitizenAsync(int id)
        {
            try
            {
                await _citizenRepo.DeleteAsync(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
