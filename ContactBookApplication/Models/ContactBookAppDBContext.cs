using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApplication.Models
{
    public class ContactBookAppDBContext : DbContext
    {
        public DbSet<Contact> contacts { get; set; }
        public ContactBookAppDBContext(DbContextOptions<ContactBookAppDBContext> options) : base(options)
        {

        }

    }
}
