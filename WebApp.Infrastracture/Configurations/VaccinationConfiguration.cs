using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Configurations
{
    internal class VaccinationConfiguration : IEntityTypeConfiguration<Vaccination>
    {
        public void Configure(EntityTypeBuilder<Vaccination> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Applied).IsRequired();

        }
    }
}
