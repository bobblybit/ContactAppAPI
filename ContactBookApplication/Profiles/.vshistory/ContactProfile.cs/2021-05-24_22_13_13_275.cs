using AutoMapper;
using ContactBookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.lastName} {src.firstName}"));
        }
    }
}
