using ContactBookApplication.Models;
using ContactBookApplication.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly IContact _ContactRepo;

        public ContactController(IContact ContactRepo)
        {
            _ContactRepo = ContactRepo;

        }

        //GET/API/CONTACT
        [HttpGet()]
        public IActionResult GetContact()
        {
            var contacts = _ContactRepo.GetContacts();
            return Ok(contacts);
        }

        //GET/API/CONTACT/0
        [HttpGet("{ID}")]
        public IActionResult GetContactByID(int ID)
        {
            var contact = _ContactRepo.GetContactByID(ID);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpGet("{Email}")]
        public IActionResult GetContactByEmail(string email)
        {
            var contact = _ContactRepo.GetContactByEmail(email);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }



    }
}
