using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsNew
{
    public class CityDAL
    {
        [Key]
        public int cityID { get; set; }
        
        public string cityName { get; set; }
        
        public string? governorate { get; set; }
 
        public string? country { get; set; }
        public int?  cityRank { get; set; }
        public int? populations { get; set; }
        // this is DAL
    }
}
