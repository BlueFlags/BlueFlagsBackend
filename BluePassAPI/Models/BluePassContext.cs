using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BluePassAPI.Models
{
    public class BluePassContext : DbContext
    {
        public BluePassContext()
        {
        }
        public BluePassContext(DbContextOptions options) : base(options)
        {
        }

        //public BluePassContext(DbContextOptions<BluePassContext> options)
        //    :base(options)
        //{
        //   Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=Blueflags;Uid=root;Pwd=12345;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Car> Car { get; set; }
    }
}
