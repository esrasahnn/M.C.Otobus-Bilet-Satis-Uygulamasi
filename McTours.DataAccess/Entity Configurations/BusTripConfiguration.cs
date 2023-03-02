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
    internal class BusTripConfiguration : IEntityTypeConfiguration<BusTrip>
    {
        public void Configure(EntityTypeBuilder<BusTrip> builder)
        {
            builder.ToTable(nameof(BusTrip));
            builder.HasKey(bt => bt.Id);
            builder.Property(bt => bt.Date).HasColumnType("datetime2(0)");
            builder.Property(bt => bt.EstimatedDuration).HasColumnType("int");
            builder.Property(bt => bt.TicketPrice).HasColumnType("money");

            //Ignore-> Göz ardı et, DB'de oluşturma
            builder.Ignore(bt => bt.HasBreakTime);

            builder.HasOne(bt => bt.Vehicle)
                .WithMany(vehicle => vehicle.BusTrips)
                .HasForeignKey(bt => bt.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bt => bt.DepartureCity)
                .WithMany()
                .HasForeignKey(bt => bt.DepartureCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bt => bt.ArrivalCity)
                .WithMany()
                .HasForeignKey(bt => bt.ArrivalCityId)
                .OnDelete(DeleteBehavior.NoAction);

            //Dikkat !! herşeyde autoinclude kullanılmaz ! Tekil navigation propertylerde sıkıntı yapmaz gibi ama koleksiyon olan navigationlarda sıkıntı yapar !
            //Şöyle bir mantık olması gerek 1 seyahate giden 1 araç vardır. 1 seyahat 1 şehre gider ve 1 şehirden kalkar aynı şekilde 1 modelin 1 markası vardır.
            builder.Navigation(b => b.Vehicle).AutoInclude();
            builder.Navigation(b => b.DepartureCity).AutoInclude();
            builder.Navigation(b => b.ArrivalCity).AutoInclude();

        }
    }
}
