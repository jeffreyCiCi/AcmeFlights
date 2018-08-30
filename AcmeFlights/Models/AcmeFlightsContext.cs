using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcmeFlights.Models
{
    public partial class AcmeFlightsContext : DbContext
    {
        public AcmeFlightsContext()
        {
        }

        public AcmeFlightsContext(DbContextOptions<AcmeFlightsContext> options)
            : base(options)
        {
        }

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
    }
}
