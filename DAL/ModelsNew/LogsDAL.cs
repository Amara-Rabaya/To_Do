using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.ModelsNew
{
    public class LogsDAL
    {
        [Key]
        public int id { get; set; }
        public DateTime creat_date { get; set; } 
        public string detales { get; set; }
    }
}
