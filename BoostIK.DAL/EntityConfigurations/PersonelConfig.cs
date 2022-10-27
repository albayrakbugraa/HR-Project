using BoostIK.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.DAL.EntityConfigurations
{
    public class PersonelConfig : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SecondName).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IdentificationNumber).HasMaxLength(11);
            builder.Property(x => x.Position).HasMaxLength(100);
            builder.Property(x => x.Salary).HasColumnType("decimal(18,2)");
            builder.Property(x => x.IBAN).HasMaxLength(26);
            builder.HasOne(x=>x.Company).WithMany(x=>x.Personels).HasForeignKey(x=>x.CompanyID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
