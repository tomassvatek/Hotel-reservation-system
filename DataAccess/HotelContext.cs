using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace DataAccess
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base()
        {
        }

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                .Property(g => g.FirstName).IsRequired();
            modelBuilder.Entity<Guest>()
                .Property(g => g.LastName).IsRequired();
            modelBuilder.Entity<Guest>()
               .Property(g => g.Email).IsRequired();

            modelBuilder.Entity<Room>()
                .HasKey(r => r.Number)
                .Property(r => r.Number)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Accommodation>()
                .Property(a => a.StartDate).IsRequired();
            modelBuilder.Entity<Accommodation>()
                .Property(a => a.EndDate).IsRequired();
            modelBuilder.Entity<Accommodation>()
                .Ignore(a => a.Days);

        }
    }
}
