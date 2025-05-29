using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelsNew
{
    public class ContinentDAL
    {
        [Key]
        public int ContinentId { get; set; }

        public string ContinentName { get; set; }    
    }
}
