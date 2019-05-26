using InternationalizationApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.DAL
{
    class Context : DbContext
    {
        public Context() : base(
            )
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Repository> repositories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<User>()
                .HasMany<Repository>(u => u.repositories)
                .WithRequired(s => s.User)
                .WillCascadeOnDelete();
        }
    }
}
