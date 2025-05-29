using System.Collections.Generic;
using System.Linq;
using DAL.DataBase;
using DAL.Interface;
using DAL.ModelsNew;
using DAL.Repositores;

namespace DAL.Repositories
{
    public class CityRepositoryDAL: ICityRepositoryDAL
    {
        private readonly DbContextDLA _context;
        private readonly ILogsRepository _logsRebo;
  

        public CityRepositoryDAL(DbContextDLA context , ILogsRepository logsRebo )
        {
            _context = context;
            _logsRebo = logsRebo;
        }

        public List<CityDAL> GetAll()
        {
            return _context.Cities.ToList();
        }

        public bool Insert(CityDAL city)
       {
            try
            {
                _context.Cities.Add(city);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    _logsRebo.Add($"City '{city.cityName}' was created.");
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool Edit(CityDAL city)
        {
            try
            {
                var existingCity = _context.Cities.FirstOrDefault(c => c.cityID == city.cityID);
                if (existingCity == null)
                    return false;

                existingCity.cityName = city.cityName;
                existingCity.governorate = city.governorate;
                existingCity.country = city.country;
                existingCity.populations = city.populations;
                existingCity.cityRank = city.cityRank;
                var result = _context.SaveChanges() ;
                if (result > 0)
                {
                    _logsRebo.Add($"City '{city.cityName}' was Updated.");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                // Optional: log exception
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var city = _context.Cities.FirstOrDefault(c => c.cityID == id);
                if (city == null)
                    return false;

                _context.Cities.Remove(city);
                var result = _context.SaveChanges() ;
                if (result > 0)
                {
                    _logsRebo.Add($"City '{city.cityName}' was Updated.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                // Optional: log exception
                return false;
            }
        }




    }
}
