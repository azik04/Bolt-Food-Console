using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class RestoranConfiguration : IEntityTypeConfiguration<Restoran>
    {
        public void Configure(EntityTypeBuilder<Restoran> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
