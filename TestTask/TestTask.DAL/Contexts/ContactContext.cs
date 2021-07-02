using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Contexts
{
    class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactContext(DbContextOptions<ContactContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
