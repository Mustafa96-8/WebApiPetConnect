using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Configurations
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(p=> p.Id);
            builder.Property(p => p.Nickname).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p =>p.Breed).IsRequired();
            builder.Property(p =>p.Color).IsRequired();
            builder.Property(p =>p.Castration).IsRequired();
            builder.Property(p =>p.PeopleAttitude).IsRequired();
            builder.Property(p =>p.AnimalAttitude).IsRequired();
            builder.Property(p =>p.OnlyOneInFamily).IsRequired();
            builder.Property(p =>p.Health).IsRequired();
            builder.Property(p => p.Height).IsRequired(false).HasMaxLength(1000);
            builder.Property(p => p.OnTreatment).IsRequired();
            builder.Property(p => p.CreatedTime).IsRequired().HasDefaultValue(DateTimeOffset.UtcNow);




            builder.ComplexProperty(p =>p.Address, b=>
            {
                b.Property(a => a.City).HasColumnName("city");
                b.Property(a => a.Street).HasColumnName("street");
                b.Property(a => a.Building).HasColumnName("building");
                b.Property(a => a.Index).HasColumnName("index");

            
            });
            builder.ComplexProperty(p =>p.Place, 
                b=> { b.Property(a => a.Value).HasColumnName("value");});
            
            builder.ComplexProperty(p =>p.Weight, 
                b=> { b.Property(a => a.Killograms).HasColumnName("weight");}); 

            builder.ComplexProperty(p =>p.ContactPhoneNumber, 
                b=> { b.Property(a => a.Number).HasColumnName("contact_phone_number");}); 
            builder.ComplexProperty(p =>p.VolunteerPhoneNumber, 
                b=> { b.Property(a => a.Number).HasColumnName("volunteer_phone_number");});


            
            //Один ко многим связь тип много фоток к 1 посту
            builder.HasMany(p => p.Photos).WithOne(); 
            builder.HasMany(p => p.Vaccinations).WithOne();

        }
    }
}
