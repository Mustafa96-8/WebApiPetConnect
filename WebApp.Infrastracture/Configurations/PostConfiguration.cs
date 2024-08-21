using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.API.Domain;

namespace WebApp.Infrastructure.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p=> p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p =>p.Breed).IsRequired();
            builder.Property(p=>p.Height).IsRequired().HasMaxLength(1000);

            builder.ComplexProperty(p => p.MainPhoto, b =>
            {
                b.Property(m => m.Path).IsRequired().HasColumnName("photo_path");
            }
            );
            //Один ко многим связь тип много фоток к 1 посту
            builder.HasMany(p => p.Photos).WithOne();
        }
    }
}
