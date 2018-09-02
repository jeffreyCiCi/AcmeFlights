using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FlightsCore.Models;

namespace Infrastructure.Repository
{
    public partial class AcmeFlightsContext : DbContext
    {
        public AcmeFlightsContext()
        {
            AddTestData();
        }

        public AcmeFlightsContext(DbContextOptions<AcmeFlightsContext> options)
            : base(options)
        {
            AddTestData();
        }

        private static bool bTestDataAdded = false;

        public virtual DbSet<AvailableSeats> AvailableSeats { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableSeats>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.FlightCode });

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FlightCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.FlightCodeNavigation)
                    .WithMany(p => p.AvailableSeats)
                    .HasForeignKey(d => d.FlightCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AvailableSeats_Flights");
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.HasKey(e => e.FlightCode);

                entity.Property(e => e.FlightCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FromLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToLocation)
                    .IsRequired()
                    .HasMaxLength(10);
            });
        }

        private void AddTestData()
        {
            if (bTestDataAdded)
            {
                return;
            }

            try
            {
                Flights.AddRange(
                    new Flights() { FlightCode = "CA579", FromLocation = "Geelong", ToLocation = "Lorne", Capacity = 5, DepartureTime = new TimeSpan(11, 35, 0) },
                    new Flights() { FlightCode = "JT231", FromLocation = "Dandenong", ToLocation = "Emerald", Capacity = 8, DepartureTime = new TimeSpan(11, 35, 0) });

                AvailableSeats.AddRange(
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 10), VacantSeats = 0 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 11), VacantSeats = 0 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 12), VacantSeats = 5 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 13), VacantSeats = 5 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 14), VacantSeats = 5 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 15), VacantSeats = 3 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 16), VacantSeats = 2 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 17), VacantSeats = 1 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 18), VacantSeats = 5 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 19), VacantSeats = 5 },
                    new AvailableSeats() { FlightCode = "CA579", Date = new DateTime(2018, 09, 20), VacantSeats = 5 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 10), VacantSeats = 8 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 11), VacantSeats = 8 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 12), VacantSeats = 8 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 13), VacantSeats = 0 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 14), VacantSeats = 8 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 15), VacantSeats = 8 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 16), VacantSeats = 4 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 17), VacantSeats = 0 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 18), VacantSeats = 0 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 19), VacantSeats = 8 },
                    new AvailableSeats() { FlightCode = "JT231", Date = new DateTime(2018, 09, 20), VacantSeats = 8 }
                );

                SaveChanges();
                bTestDataAdded = true;
            }
            catch (Exception e)
            {
                throw new DbUpdateException("Error when seeding data.", e);
            }
        }
    }
}
