using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBiz.Core.Models;

namespace MyBiz.Configurations
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FullName)
                    .IsRequired()
                    .HasMaxLength(90);
           builder.Property(x=>x.Position)
                .IsRequired()
                .HasMaxLength(70);
            builder.Property(x => x.Department)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
