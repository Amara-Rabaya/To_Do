using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tranning_pro.Models
{
    public class City
    {
        public int cityID { get; set; }
        
        public string cityName { get; set; }
        
        public string? governorate { get; set; }
 
        public string? country { get; set; }
        public int?  cityRank { get; set; }
        public int? populations { get; set; }
    }
}
