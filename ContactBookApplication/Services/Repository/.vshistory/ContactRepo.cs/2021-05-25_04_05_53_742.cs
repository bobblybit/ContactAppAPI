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
        private readonly ContactBookAppDBContext _contxt;
        public ContactRepo(ContactBookAppDBContext context)
        {
            _contxt = context;
        }
        public bool CreateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            _contxt.contacts.Add(contact);

            if(_contxt.SaveChanges() > 0)
            {
                return true;
            }
            return false;

        }

        public bool DeleteContact()
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByEmail(string Email)
        {
            return _contxt.contacts.FirstOrDefault(x => x.Email == Email);
        }

        public Contact GetContactByID(int ID)
        {
            return _contxt.contacts.FirstOrDefault(x => x.ID == ID);
        }

        public IEnumerable<Contact> GetContacts()
        {

            return _contxt.contacts.ToList();
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
