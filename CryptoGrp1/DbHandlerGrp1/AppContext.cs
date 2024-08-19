using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandlerGrp1
{
    public class AppContext : DbContext
    {
        //creating the tabels for the Diary database using SQL Server DbSet
        public DbSet<Password> Passwords { get; set; }
        public DbSet<UserName> Users { get; set; }
        // sending the Connictionstring 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ItsakerhetGrp1se;Integrated Security=True;"); 
        }

    }
}
