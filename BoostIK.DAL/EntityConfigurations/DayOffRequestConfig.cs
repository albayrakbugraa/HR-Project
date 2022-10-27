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
    public class DayOffRequestConfig : IEntityTypeConfiguration<DayOffRequest>
    {
        public void Configure(EntityTypeBuilder<DayOffRequest> builder)
        {
            builder.HasOne(a => a.Personel).WithMany(b => b.DayOffRequests).HasForeignKey(c => c.PersonelID).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(a => a.Company).WithMany(b => b.DayoffRequests).HasForeignKey(c => c.CompanyID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Permission).WithMany(b => b.DayOffRequests).HasForeignKey(c => c.PermissionID).OnDelete(DeleteBehavior.NoAction).IsRequired();

        }
    }
}
