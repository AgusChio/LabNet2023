using System.Collections.Generic;

namespace Practica3.Logic
{
    public interface IRepository<T>
    {

        List<T> GetAll();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
