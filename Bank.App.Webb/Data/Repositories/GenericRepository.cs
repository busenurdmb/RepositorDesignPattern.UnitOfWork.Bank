

using Bank.App.Webb.Data.Context;
using Bank.App.Webb.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Bank.App.Webb.Data.Repositories
{
    //T bir class olmalı ve new lene bilmeli t içine gidip bir abstract koymasın yada 
    //bir static
    public class GenericRepository<T>: IGenericRepository<T> where T:class,new()
    {
        private readonly BankContext _bankContext;

        public GenericRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        //IQureyable=>db tarafında işi bitmemiş,where ,find
        public void Create(T entity)
        {
            _bankContext.Set<T>().Add(entity);
            
        }
        public void Remove(T entity)
        {
            _bankContext.Set<T>().Remove(entity);
        
        }
        public void Update(T entity)
        {
            _bankContext.Set<T>().Update(entity);
            
        }
        public List<T> GetAll(/*bool isTracking=false*/)
        {
            //dediğim zaman efcore bütün listeyi çekiyor ve çekmiş oldğu listeyi
            //izliyor.
            //AsNoTracking durumu söz konusu değil
          return  _bankContext.Set<T>().ToList();
        }
        public T GetById(object id)
        {
            return _bankContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetQueryable()
        {
            //data queryable olarak gelicek
            return _bankContext.Set<T>().AsQueryable();
        }
    }
}
