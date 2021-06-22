﻿using ContactBookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.Services.Interface
{
    public interface IContact
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContactByID(int ID);
        Contact GetContactByEmail(string Email);
        Contact SearchContactByTerm(string term);
        bool DeleteContact();
        bool CreateContact();
        bool UpdateContact();
        bool UpdateProfileImage();
    }
}
