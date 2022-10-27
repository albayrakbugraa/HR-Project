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
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            //Company
            builder.HasMany(a => a.DayoffRequests).WithOne(b => b.Company).HasForeignKey(c => c.CompanyID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Manager).WithOne().HasForeignKey<Company>(x=>x.ManagerId).HasConstraintName("FK_COMPANY_MANAGER");
            builder.Property(x => x.CompanyName).IsRequired();
            builder.Property(x => x.Adress).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.MailExtension).IsRequired();
        }
    }
}
