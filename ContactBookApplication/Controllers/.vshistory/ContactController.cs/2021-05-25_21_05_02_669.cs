using AutoMapper;
using CloudinaryDotNet;
using ContactBookApplication.DTO;
using ContactBookApplication.Models;
using ContactBookApplication.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        public ContactController(IContact ContactRepo, IMapper mapper, IConfiguration config)
        {
            Account account = new Account
            {
                Cloud = config.GetSection("CloudinarySettings:Cloud name").Value,
                ApiKey = config.GetSection("CloudinarySettings:Cloud name").Value,
                ApiSecret = config.GetSection("CloudinarySettings:Cloud name").Value,
            };

            _ContactRepo = ContactRepo;
            _mapper = mapper;

        }

        [HttpGet("{contactEmail}", Name="GetContactByEmail")]
        public IActionResult GetContactByEmail(string contactEmail)
        {
            var contact = _ContactRepo.GetContactByEmail(contactEmail);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ContactReadDto>(contact));
        }

        //Post API Contact
        [HttpPost]
        public IActionResult CreateContact(ContactCreateDto newContact)
        {
            var contactmodel = _mapper.Map<Contact>(newContact);
            _ContactRepo.CreateContact(contactmodel);

            var readContactDto = _mapper.Map<ContactReadDto>(contactmodel);
            return CreatedAtRoute(nameof(GetContactByEmail), new { contactEmail = readContactDto.Email}, readContactDto);
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


        //Update Action PUT/API/CONTACT/0

        [HttpPut("{contactId:int}")]
        public IActionResult UpdateContact(int contactId, UpdateContactDTO contactToUpdate)
        {
            var contactFromRepo = _ContactRepo.GetContactByID(contactId);

            if (contactFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(contactToUpdate, contactFromRepo);
            _ContactRepo.UpdateContact(contactFromRepo);
            _ContactRepo.savechanges();

            return NoContent();
        }

        //DELETE api/contact/{id}
        [HttpDelete("{DeleteItemId}")]
        public IActionResult DeleteContact(int DeleteItemId)
        {
            var contactFromRepo = _ContactRepo.GetContactByID(DeleteItemId);

            if (contactFromRepo == null)
            {
                return NotFound();
            }
            _ContactRepo.DeleteContact(contactFromRepo);
            _ContactRepo.savechanges();
            return NoContent();
        }

    }
}
