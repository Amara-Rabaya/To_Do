using DAL.Interface;
using DAL.ModelsNew;
using Tranning_pro.BLInterface;
using Tranning_pro.Helper;

namespace Tranning_pro.BL
{
    public class CityBLServece: ICityBLServece
    {
        private readonly ICityRepositoryDAL _ICityRepositoryDAL;
        private readonly ILogsRepository _ILogsRepository;
        public CityBLServece(ICityRepositoryDAL icityRepositoryDAL, ILogsRepository iLogsRepository)
        {
            _ICityRepositoryDAL = icityRepositoryDAL; 
            _ILogsRepository = iLogsRepository;
        }

        public List<CityDAL> gitAll()
        {
            try
            {
                var x= _ICityRepositoryDAL.GetAll();
                return x;
                
            }
            catch (Exception ex){
                return null;
               
                 
            }
        }
        public bool addCity(CityDAL city) {
            try
            {
                var rank = cityRankHelper.Calculate(city.populations);
                var cityModel = new CityDAL
                {
                    cityID = city.cityID,
                    cityName = city.cityName,
                    populations = city.populations,
                    governorate = city.governorate,
                    country = city.country, 
                    cityRank = rank,    
                };
                _ICityRepositoryDAL.Insert(cityModel);
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
                _ICityRepositoryDAL.Edit(city);  
                return true;
            }
            catch {  return false;}
        }
        public bool deleteCity(int id) {
            try
            {
                _ICityRepositoryDAL.Delete(id);
                return true;
            }
            catch { return false; }
        }
    }
}
