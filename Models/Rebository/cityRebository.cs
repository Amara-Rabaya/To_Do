using System.Collections.Generic;
using System.Linq;
using Tranning_pro.Data;
using Tranning_pro.Models;

namespace Tranning_pro.Repositories
{
    public class CityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly LogsRepository _logsRebo;

        public CityRepository(ApplicationDbContext context , LogsRepository logsRebo )
        {
            _context = context;
            _logsRebo = logsRebo;
        }

        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public bool Insert(City city)
       {
            try
            {
                city.cityRank = CalcCityRank.Calculate(city.populations);
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
        public bool Edit(City city)
        {
            try
            {
                var existingCity = _context.Cities.FirstOrDefault(c => c.cityID == city.cityID);
                if (existingCity == null)
                    return false;

                existingCity.cityName = city.cityName;
                existingCity.governorate = city.governorate;
                existingCity.country = city.country;
<<<<<<< HEAD
                existingCity.populations = city.populations;
                existingCity.cityRank = CalcCityRank.Calculate(city.populations);
=======
                existingCity.cityRank = city.cityRank;
                existingCity.populations = city.populations;
>>>>>>> 955201b083e84a6163c162a3a83df828799523b4

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
