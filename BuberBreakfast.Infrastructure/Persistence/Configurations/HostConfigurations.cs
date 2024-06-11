using BuberBreakfast.Domain.HostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberBreakfast.Infrastructure.Persistence.Configurations;

public class HostConfigurations : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id).HasConversion(id => id.Value, guid => new(guid));

        builder.OwnsMany(
            h => h.MenuIds,
            mib =>
            {
                mib.WithOwner().HasForeignKey("HostId");
                mib.HasKey("Id");
                mib.Property(mi => mi.Value).HasColumnName("HostMenuId");
            }
        );
    }
}
