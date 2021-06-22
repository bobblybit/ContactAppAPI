using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.Models
{
    public class Contact
    {

        public int ID { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string Adrress { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhotoUrl { get; set; }

    }
}
