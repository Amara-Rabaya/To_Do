using DAL.ModelsNew;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tranning_pro.BLInterface
{
    public interface ICitizenBLService
    {
        Task<List<Citizen>> GetAllCitizensAsync();
        Task<Citizen> GetCitizenByIdAsync(int id);
        Task<bool> AddCitizenAsync(Citizen citizen);
        Task<bool> UpdateCitizenAsync(int id, Citizen citizen);
        Task<bool> DeleteCitizenAsync(int id);
    }
}
