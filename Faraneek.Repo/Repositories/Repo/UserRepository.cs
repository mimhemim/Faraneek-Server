using Faraneek.Repo.Infrastructure;
using Faraneek.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Faraneek.Data.DatabaseContext;
using Faraneek.Repo.Repositories.Interface;

namespace Faraneek.Repo.Repositories.Repo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext _db;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _db= (_db ?? (FaraneekDbContext) _db );
        }
    }
}
