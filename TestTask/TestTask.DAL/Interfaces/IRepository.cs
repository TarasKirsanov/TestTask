using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ReadAll();
        T Read(string key);
        void Create(T item);
        void Update(T item);
        void Delete(string key);
    }
}
