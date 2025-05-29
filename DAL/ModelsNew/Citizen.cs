using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelsNew
{
    public class Citizen
    {
        [Key]
        public int Id {  get; set; }    
        public string Fullname { get; set; }    
        public string bartidate { get; set; }
        public CitizenDitales Detales { get; set; }

    }
    public class CitizenDitales
    {
        public string major { get; set; }
        public string City { get; set;}
        public List<Notes> CitizenNotes { get; set;}  
    }
    public class Notes
    {
        public int noteText { get; set; }
        public int noteDate { get; set; }

    }

}
