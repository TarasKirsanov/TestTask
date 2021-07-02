using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.WEB.Interfaces;
using TestTask.WEB.Models;

namespace TestTask.WEB.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(ContactModel contact)
        {
            contact.Id = Guid.NewGuid();
            await _repository.CreateAsync(contact);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ContactModel> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<ContactModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateAsync(ContactModel contact)
        {
            await _repository.UpdateAsync(contact);
        }
    }
}
