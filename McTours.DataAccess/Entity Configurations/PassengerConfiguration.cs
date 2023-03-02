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
    internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable(nameof(Passenger));
            builder.HasKey(pas => pas.Id);
            builder.Property(pas => pas.FirstName).IsRequired().HasColumnType("nvarchar(20)");
            builder.Property(pas => pas.LastName).IsRequired().HasColumnType("nvarchar(20)");
            builder.Property(pas => pas.DateOfBirth).IsRequired().HasColumnType("date");
            builder.Property(pas => pas.IdentityNumber).IsRequired().IsUnicode().HasColumnType("nvarchar(11)");

            //Bu şekilde yaparsak benzersiz t.c kimlik no'ları üretmiş oluruz.
            //Bunu IdentityNumberUniqueIndex şeklinde bir isimle migrationa eklenecek.
            builder.HasIndex(pass => pass.IdentityNumber).IsUnique();
            builder.HasData(
                new Passenger() { Id = 1, IdentityNumber = "12345678912", FirstName = "Esra", LastName = "Şahin", Gender=Gender.Female, DateOfBirth = new DateTime(1994, 11, 14) },
                new Passenger() { Id = 2, IdentityNumber = "35832121631", FirstName = "Mahmut", LastName = "Seka", Gender = Gender.Male, DateOfBirth = new DateTime(1990, 09, 10) },
                new Passenger() { Id = 3, IdentityNumber = "13895958912", FirstName = "Ahmet", LastName = "Aslan", Gender = Gender.Male, DateOfBirth = new DateTime(1992, 12, 24) },
                new Passenger() { Id = 4, IdentityNumber = "12389566812", FirstName = "Halil", LastName = "Ağdaş", Gender = Gender.Male, DateOfBirth = new DateTime(1997, 11, 15) }

                );


        }
    }
}
