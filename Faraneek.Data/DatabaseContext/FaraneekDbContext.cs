using Faraneek.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Faraneek.Data.DatabaseContext
{

    

    public class FaraneekDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=FaraneekAdb;Integrated Security=True;MultipleActiveResultSets=True;");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<BankCard> BankCards { get; set; }


    }

   


}
