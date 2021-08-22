using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Services.Report.Core.Models;

namespace PhoneBook.Services.Report.Data.Configurations
{
    public class ReportsConfiguration : IEntityTypeConfiguration<Reports>
    {
        public void Configure(EntityTypeBuilder<Reports> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequestDate).IsRequired();

            builder.Property(x => x.Status).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Data).HasMaxLength(int.MaxValue);

            builder.ToTable("Reports", "public" );
        }
    }
}
