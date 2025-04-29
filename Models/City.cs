using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tranning_pro.Models
{
    public class City
    {
        public int? cityID { get; set; }
        [Required]
        [DisplayName("Enter the City Name...")]
        [StringLength(50, MinimumLength =4)]
        public string cityName { get; set; }
        [DisplayName("Enter the City governorate...")]
        public string? governorate { get; set; }
        [DisplayName("Enter the City country...")]
        public string? country { get; set; }
        public int?  cityRank { get; set; }
        public int? populations { get; set; }
    }
}
