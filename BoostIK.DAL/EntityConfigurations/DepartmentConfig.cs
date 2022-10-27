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
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(x => x.Personels).WithOne(y => y.Department).HasForeignKey(z => z.DepartmentID).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            //builder.Property(x => x.CompanyID).IsRequired();
            //builder.HasOne(x => x.Company).WithMany(y => y.Departments).HasForeignKey(z => z.CompanyID).IsRequired();
            //builder.HasMany(x => x.Personels).WithOne(y => y.Department).HasForeignKey(z => z.DepartmentID).IsRequired();
        }
    }
}
