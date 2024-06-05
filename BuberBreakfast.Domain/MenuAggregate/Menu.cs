using BuberBreakfast.Domain.BreakfastAggregate.ValueObjects;
using BuberBreakfast.Domain.Common.Models;
using BuberBreakfast.Domain.Common.ValuesObjects;
using BuberBreakfast.Domain.HostAggregate.ValueObjects;
using BuberBreakfast.Domain.MenuAggregate.Entities;
using BuberBreakfast.Domain.MenuAggregate.ValueObjects;
using BuberBreakfast.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberBreakfast.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required AverageRating? AverageRating { get; init; }
    public required HostId HostId { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; init; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    private List<MenuSection> _sections = [];

    public IReadOnlyList<BreakfastId> BreakfastIds => _breakfastIds.AsReadOnly();
    private List<BreakfastId> _breakfastIds = [];

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    private List<MenuReviewId> _menuReviewIds = [];

    private Menu(MenuId id)
        : base(id) { }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        AverageRating? averageRating = null,
        List<MenuSection>? sections = null
    ) =>
        new(MenuId.CreateUnique())
        {
            Name = name,
            Description = description,
            AverageRating = averageRating,
            HostId = hostId,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow,
            _sections = sections ?? [],
        };
}
