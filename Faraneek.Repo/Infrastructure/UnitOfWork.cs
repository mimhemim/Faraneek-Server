﻿using Faraneek.Repo.Repositories.Interface;
using Faraneek.Repo.Repositories.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Faraneek.Repo.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        #region ctor
        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }
        #endregion

        #region privaterepository
        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_db);
                }
                return userRepository;
            }
        }
        #endregion


        #region save
        public void Save()
        {
            _db.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
        }

        #endregion


        #region dispose
        private bool disposed = false;


          

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
