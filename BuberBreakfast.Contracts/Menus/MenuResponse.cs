namespace BuberBreakfast.Contracts.Menus;

public record MenuResponse(
    Guid Id,
    string Name,
    string Description,
    double? AverageRating,
    List<MenuSectionResponse> Sections,
    Guid HostId,
    List<string> BreakfastIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items
);

public record MenuItemResponse(string Id, string Name, string Description);
