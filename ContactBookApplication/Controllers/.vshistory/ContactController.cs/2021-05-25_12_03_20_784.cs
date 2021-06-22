using AutoMapper;
using ContactBookApplication.DTO;
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
        private readonly IMapper _mapper;

        public ContactController(IContact ContactRepo, IMapper mapper)
        {
            _ContactRepo = ContactRepo;
            _mapper = mapper;

        }



        //Post API Contact
        [HttpPost]
        public IActionResult CreateContact(ContactCreateDto newContact)
        {
            var contactmodel = _mapper.Map<Contact>(newContact);
            _ContactRepo.CreateContact(contactmodel);

            var readContactDto = _mapper.Map<ContactReadDto>(contactmodel);
            return CreatedAtRoute(nameof(GetContactByEmail), new {Email = readContactDto.Email}, readContactDto);
        }


        //GET/API/CONTACT
        [HttpGet()]
        public IActionResult GetContact()
        {
            var contacts = _ContactRepo.GetContacts();
            return Ok(_mapper.Map<IEnumerable<ContactReadDto>>(contacts));
        }

        //GET/API/CONTACT/0
        [HttpGet("{contactId:int}")]
        public IActionResult GetContactByID(int contactId)
        {
            var contact = _ContactRepo.GetContactByID(contactId);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ContactReadDto>(contact));
        }

        [HttpGet("{contactEmail}", Name = "GetContactByEmail")]
        public IActionResult GetContactByEmail(string contactEmail)
        {
            var contact = _ContactRepo.GetContactByEmail(contactEmail);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ContactReadDto>(contact));
        }



    }
}
