using BuberBreakfast.Domain.Common.Models;

namespace BuberBreakfast.Domain.Common.ValuesObjects;

public sealed class AverageRating : ValueObject
{
    public double Value { get; private set; } = 0.0;
    public int NumRatings { get; private set; } = 0;

    private AverageRating() { }

    public static AverageRating Create(double rating = 0, int numRatings = 0) =>
        new() { Value = rating, NumRatings = numRatings };

    public AverageRating AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
        return this;
    }

    internal AverageRating RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
        return this;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
