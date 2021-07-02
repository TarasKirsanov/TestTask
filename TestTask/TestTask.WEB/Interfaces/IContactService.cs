using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.WEB.Models;

namespace TestTask.WEB.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactModel>> GetAllAsync();
        Task<ContactModel> GetAsync(Guid id);
        Task CreateAsync(ContactModel contact);
        Task UpdateAsync(ContactModel contact);
        Task DeleteAsync(Guid id);
    }
}
