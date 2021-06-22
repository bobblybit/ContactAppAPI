using ContactBookApplication.Models;
using ContactBookApplication.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContact _Contact;

        public ContactController(IContact Contact)
        {
            _Contact = Contact;
        }

        [HttpGet()]
        public IActionResult GetContact()
        {
            var contacts = _Contact.GetContacts();
            return Ok(contacts);
        }


        [HttpGet("{ID}")]
        public IActionResult GetContactByID(int ID)
        {
            var contact = _Contact.GetContactByID(ID);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }



    }
}
