using DAL.ModelsNew;
using Tranning_pro.Repositories;

namespace Tranning_pro.BL
{
    public class CityBLServece
    {
        private readonly CityRepositoryDAL _CityRepositoryDAL;
        public CityBLServece(CityRepositoryDAL cityRepositoryDAL)
        {
            _CityRepositoryDAL = cityRepositoryDAL; 
        }

        public List<CityDAL> gitAll()
        {
            try
            {
                _CityRepositoryDAL.GetAll();    
                return true;
            }
            catch { 
                return false;   
            }
        }
        public bool addCity(CityDAL city) {
            try
            {
                _CityRepositoryDAL.Insert(city);
                return true;

            }
            catch
            {
                return false;   
            }
        
        }
        public bool updateCity(CityDAL city) {
            try
            {
                _CityRepositoryDAL.Edit(city);  
                return true;
            }
            catch {  return false;}
        }
        public bool deleteCity(int id) {
            try
            {
                _CityRepositoryDAL.Delete(id);
                return true;
            }
            catch { return false; }
        }
    }
}
