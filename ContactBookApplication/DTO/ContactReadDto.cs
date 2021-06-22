using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.DTO
{
    public class ContactReadDto
    {
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public string Adrress { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
    }
}
