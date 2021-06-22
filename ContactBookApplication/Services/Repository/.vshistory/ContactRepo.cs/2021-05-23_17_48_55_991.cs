using ContactBookApplication.Models;
using ContactBookApplication.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.Services.Repository
{
    public class ContactRepo : IContact
    {
        public bool CreateContact()
        {
            throw new NotImplementedException();
        }

        public bool DeleteContact()
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByID(int ID)
        {
            return new Contact {
                ID = 0,
                Adrress = "Lagos",
                Email = "by juve@gmail.com",
                firstName = "Young",
                lastName = "Solomon",
                phoneNumber = "08036142253" };
        }

        public IEnumerable<Contact> GetContacts()
        {
            var Contacts = new List<Contact>
            {
                 new Contact
                 {
                     ID = 0,
                     Adrress = "Lagos",
                     Email = "by juve@gmail.com",
                     firstName = "Young",
                     lastName = "Solomon",
                     phoneNumber = "08036142253"
                 },

                  new Contact
                  {
                     ID = 1,
                     Adrress = "Abuja",
                     Email = "byjuve@gmail.com",
                     firstName = "Jero",
                     lastName = "Solomon",
                     phoneNumber = "08036142253"
                  }
            };
        }

        public Contact SearchContactByTerm(string term)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContact()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProfileImage()
        {
            throw new NotImplementedException();
        }
    }
}
