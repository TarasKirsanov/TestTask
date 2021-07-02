using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.WEB.Interfaces;
using TestTask.WEB.Models;

namespace TestTask.WEB.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private IDbContextFactory<ContactContext> _contextFactory;

        public ContactRepository(IDbContextFactory<ContactContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateAsync(ContactModel contact)
        {
            using var db = _contextFactory.CreateDbContext();
            await db.Contacts.AddAsync(contact);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            using var db = _contextFactory.CreateDbContext();
            var entity = await db.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);
            if (entity == null)
                return;
            db.Contacts.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<ContactModel> GetAsync(Guid id)
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);
        }

        public async Task<IEnumerable<ContactModel>> GetAllAsync()
        {
            using var db = _contextFactory.CreateDbContext();
            return await db.Contacts.ToListAsync();
        }

        public async Task UpdateAsync(ContactModel contact)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Contacts.Attach(contact);
            db.Entry(contact).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
