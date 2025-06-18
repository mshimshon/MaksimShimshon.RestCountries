﻿namespace MaksimShimshon.RestCountries.Entities
{
    public record class CountryIdentifier
    {
        public string CCA2 { get; init; } = null!;
        public string CCN3 { get; init; } = null!;

        public string CCA3 { get; init; } = null!;

        public string CIOC { get; init; } = string.Empty;
        public string FIFA { get; init; } = string.Empty;
        public string Root { get; init; } = null!;
        public ICollection<string> RootSuffixes { get; init; } = null!;
    }
}
