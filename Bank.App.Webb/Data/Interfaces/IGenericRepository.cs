using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Data.Interfaces
{
    public interface IGenericRepository<T> where T:class ,new()
    {
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);
        List<T> GetAll();
        T GetById(object id);
        IQueryable<T> GetQueryable();
    }
}
