using Microsoft.EntityFrameworkCore;

namespace PersonAddresses.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonAddress>().HasKey(s => new {s.AddressID, s.PersonID});
        }

        public DbSet<Address> Addresses {get; set;}
        public DbSet<Person> Persons {get; set;}
        public DbSet<PersonAddress> PersonAddress {get; set;}
    }
}