using BuberBreakfast.Application.Common.Interfaces;

namespace BuberBreakfast.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
