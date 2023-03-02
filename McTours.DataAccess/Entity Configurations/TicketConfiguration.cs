using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.DataAccess.Entity_Configurations
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));
            builder.HasKey(tic => tic.Id);

            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("money");
            
            builder.Property(t => t.SeatNumber)
                .IsRequired()
                .HasColumnType("smallint");

            builder
                .HasOne(pass => pass.Passenger)
                .WithMany()
                .HasForeignKey(pass => pass.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(trip => trip.BusTrip)
                .WithMany()
                .HasForeignKey(trip => trip.BusTripId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(ticket => new
            {
                ticket.BusTripId,
                ticket.SeatNumber
            }).IsUnique();
        }
    }
}
