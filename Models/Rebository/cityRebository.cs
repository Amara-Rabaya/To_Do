using System.Collections.Generic;
using System.Linq;
using Tranning_pro.Data;
using Tranning_pro.Models;

namespace Tranning_pro.Repositories
{
    public class CityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public bool Insert(City city)
        {
            try
            {
                _context.Cities.Add(city);
               var result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else { return false; }  
            }
            catch (Exception)
            {
                // Optional: log the exception or rethrow if needed
                return false;
            }
        }
    }
}
