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
    public class SpendingConfig : IEntityTypeConfiguration<Spending>
    {
        public void Configure(EntityTypeBuilder<Spending> builder)
        {
            builder.HasOne(a => a.Personel).WithMany(b => b.Spendings).HasForeignKey(c => c.PersonelID).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(a => a.Company).WithMany(b => b.Spendings).HasForeignKey(c => c.CompanyID).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.Property(a => a.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(a => a.TypeOfSpending).IsRequired();
            builder.Property(a => a.CurrencyUnit).IsRequired();
            builder.Property(a => a.SpendingDate).IsRequired();
            builder.Property(a => a.FilePath).IsRequired();
        }
    }
}
