using DAL.ModelsNew;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IcitizenRebositoryDAL
    {
        Task<List<Citizen>> GetAllAsync();
        Task<Citizen> GetByIdAsync(int id);
        Task AddAsync(Citizen citizen);
        Task UpdateAsync(int id, Citizen citizen);
        Task DeleteAsync(int id);
    }
}
