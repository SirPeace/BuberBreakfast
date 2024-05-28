using BuberBreakfast.Domain.Common.Models;
using BuberBreakfast.Domain.Common.ValuesObjects;
using BuberBreakfast.Domain.Dinner.ValueObjects;
using BuberBreakfast.Domain.HostAggregate.ValueObjects;
using BuberBreakfast.Domain.MenuAggregate.Entities;
using BuberBreakfast.Domain.MenuAggregate.ValueObjects;
using BuberBreakfast.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberBreakfast.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required AverageRating AverageRating { get; init; }
    public required HostId HostId { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; init; }

    private readonly List<MenuSection> _sections = [];
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    private readonly List<DinnerId> _dinnerIds = [];
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    private readonly List<MenuReviewId> _menuReviewIds = [];
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    private Menu(MenuId id)
        : base(id) { }

    public static Menu Create(
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId
    ) =>
        new(MenuId.CreateUnique())
        {
            Name = name,
            Description = description,
            AverageRating = averageRating,
            HostId = hostId,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow,
        };
}
