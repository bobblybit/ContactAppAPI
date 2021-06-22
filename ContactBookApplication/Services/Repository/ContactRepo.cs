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


        public bool savechanges()
        {
            return _contxt.SaveChanges() >= 0;
        }

        public void CreateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            _contxt.contacts.Add(contact);

            savechanges();

        }

        public void DeleteContact(Contact contactToRemove)
        {
            if (contactToRemove == null)
            {
                throw new ArgumentNullException(nameof(contactToRemove));
            }
            _contxt.Remove(contactToRemove);
            savechanges();
        }

        public Contact GetContactByEmail(string Email)
        {
            return _contxt.contacts.Where(x => x.Email == Email).FirstOrDefault();
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

        public void UpdateContact(Contact contact)
        {
            //nothing goes here
        }

        public bool UpdateProfileImage()
        {
            throw new NotImplementedException();
        }
    }
}
