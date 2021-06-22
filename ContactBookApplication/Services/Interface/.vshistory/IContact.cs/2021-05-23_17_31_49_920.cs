using ContactBookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.Services.Interface
{
    interface IContact
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContactByID();
        bool DeleteContact();
        bool CreateContact();
        bool UpdateContact();

    }
}
