using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtallahHamza_Corilus.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string AfterName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsAtive { get; set; }
    }
}
