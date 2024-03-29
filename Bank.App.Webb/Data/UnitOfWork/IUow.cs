﻿using Bank.App.Webb.Data.Interfaces;

namespace Bank.App.Webb.Data.UnitOfWork
{
    public interface IUow
    {
        IGenericRepository<T> GetRepository<T>() where T : class, new();
         void SaveChanges();
    }
}