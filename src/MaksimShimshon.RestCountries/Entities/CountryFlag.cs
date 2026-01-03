using MaksimShimshon.RestCountries.Entities.Enums;

namespace MaksimShimshon.RestCountries.Entities;

public record class CountryFlag
{
    public string Value { get; init; } = null!;
    public FlagType Type { get; init; }
}
