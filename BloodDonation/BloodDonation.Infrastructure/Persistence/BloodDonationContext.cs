using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Persistence
{
    public class BloodDonationContext : DbContext
    {
        public BloodDonationContext(DbContextOptions<BloodDonationContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Logradouro> Logradouro { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Logradouro>(e =>
            {
                e.HasKey(l => l.Id);
                e.HasIndex(l => l.Name);
            });

            builder.Entity<State>(e =>
            {
                e.HasKey(s => s.Id);
                e.HasIndex(s => s.Name);
            });

            builder.Entity<City>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasIndex(e => e.Name);

                e.HasOne(c => c.State)
                    .WithOne()
                    .HasForeignKey<State>("StateId")
                    .IsRequired();
            });

            builder.Entity<Address>(e =>
            {
                e.HasKey(a => a.Id);
                e.HasOne(a => a.City)
                    .WithOne()
                    .HasForeignKey<City>("CityId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                e.HasOne(a => a.Logradouro)
                    .WithOne()
                    .HasForeignKey<Logradouro>("LogradouroId")
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });

            builder.Entity<BloodStock>(e => 
            {
                e.HasKey(bs => bs.Id);
            });

            builder.Entity<Donation>(e => 
            {
                e.HasKey(d => d.Id);
                e.HasIndex(d => d.IdDonor);
                e.HasIndex(d => d.IdEmployee);

                e.HasOne(d => d.Donor)
                    .WithMany(d => d.Donations)
                    .HasForeignKey(d => d.IdDonor)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.Employee)
                    .WithMany(e => e.Donations)
                    .HasForeignKey (e => e.IdEmployee)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Donor>(e => 
            {
                e.HasKey(d => d.Id);
                e.HasIndex(d => d.Name);
                e.HasIndex(d => d.Email);

                e.HasMany(d => d.Donations)
                    .WithOne(d => d.Donor)
                    .HasForeignKey(d => d.IdDonor)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Employee>(e => 
            {
                e.HasKey(e => e.Id);
                e.HasIndex(e => e.Name);
                e.HasIndex(e => e.Email);

                e.HasMany(d => d.Donations)
                    .WithOne(e => e.Employee)
                    .HasForeignKey(e => e.IdEmployee)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }
    }
}
