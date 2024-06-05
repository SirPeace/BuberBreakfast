using BuberBreakfast.Domain.BreakfastAggregate.ValueObjects;
using BuberBreakfast.Domain.HostAggregate.ValueObjects;
using BuberBreakfast.Domain.MenuAggregate;
using BuberBreakfast.Domain.MenuAggregate.Entities;
using BuberBreakfast.Domain.MenuAggregate.ValueObjects;
using BuberBreakfast.Domain.MenuReviewAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberBreakfast.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MenuId(value));
        builder.Property(m => m.Name).HasMaxLength(100);
        builder.Property(m => m.Description).HasMaxLength(1000);
        builder.Property(m => m.HostId).HasConversion(id => id.Value, value => new HostId(value));
        
        builder.OwnsOne(m => m.AverageRating);
        builder.OwnsMany(m => m.Sections, ConfigureMenuSectionsTable);
        builder.OwnsMany(m => m.BreakfastIds, ConfigureMenuBreakfastIdsTable);
        builder.OwnsMany(m => m.MenuReviewIds, ConfigureMenuReviewIdsTable);

        var sections = builder.Navigation(m => m.Sections);
        sections.Metadata.SetField("_sections");
        sections.UsePropertyAccessMode(PropertyAccessMode.Field);

        var breakfastIds = builder.Navigation(m => m.BreakfastIds);
        breakfastIds.Metadata.SetField("_breakfastIds");
        breakfastIds.UsePropertyAccessMode(PropertyAccessMode.Field);
        
        var menuReviewIds = builder.Navigation(m => m.MenuReviewIds);
        menuReviewIds.Metadata.SetField("_menuReviewIds");
        menuReviewIds.UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(OwnedNavigationBuilder<Menu, MenuSection> builder)
    {
        builder.ToTable("MenuSections");
        builder.WithOwner().HasForeignKey("MenuId");
        builder.HasKey(nameof(MenuSection.Id), "MenuId");

        builder
            .Property(ms => ms.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MenuSectionId(value));
        builder.Property(ms => ms.Name).HasMaxLength(100);
        builder.Property(ms => ms.Description).HasMaxLength(1000);
        
        builder.OwnsMany(s => s.Items, ConfigureMenuSectionItemsTable);

        var items = builder.Navigation(ms => ms.Items);
        items.Metadata.SetField("_items");
        items.UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionItemsTable(
        OwnedNavigationBuilder<MenuSection, MenuItem> builder
    )
    {
        builder.ToTable("MenuItems");
        builder.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
        builder.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

        builder
            .Property(msi => msi.Id)
            .HasColumnName("MenuItemId")
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MenuItemId(value));
        builder.Property(msi => msi.Name).HasMaxLength(100);
        builder.Property(msi => msi.Description).HasMaxLength(1000);
    }

    private void ConfigureMenuBreakfastIdsTable(OwnedNavigationBuilder<Menu, BreakfastId> builder)
    {
        builder.ToTable("MenuBreakfastIds");
        builder.HasKey("Id");
        builder.WithOwner().HasForeignKey("MenuId");

        builder.Property(mbi => mbi.Value).HasColumnName("BreakfastId").ValueGeneratedNever();
    }

    private void ConfigureMenuReviewIdsTable(OwnedNavigationBuilder<Menu, MenuReviewId> builder)
    {
        builder.ToTable("MenuReviewIds");
        builder.HasKey("Id");
        builder.WithOwner().HasForeignKey("MenuId");

        builder.Property(mri => mri.Value).HasColumnName("ReviewId").ValueGeneratedNever();
    }
}
