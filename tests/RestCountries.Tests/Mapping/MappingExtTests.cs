﻿using MaksimShimshon.RestCountries.Embedded;
using MaksimShimshon.RestCountries.Entities.Mapping;
using MaksimShimshon.RestCountries.Tests.Engine;

namespace MaksimShimshon.RestCountries.Tests.Mapping
{
    public class MappingExtTests : EngineTests
    {
        [Theory]
        [InlineData("countriesV3.1")]
        [InlineData("countriesV3")]
        public void EntityCountryMapping_Tests(string version)
        {
            var rCountry = GetOrCache(version);
            var jsonObjects = rCountry.DeserializeCountries(RestCountriesEmbed.GetVersion(version));
            var countries = rCountry.ExtractToDataModels(jsonObjects);
            foreach (var country in countries)
            {
                country.AsEntity();
                foreach (var item in country.Currencies) item.AsEntity();
                foreach (var item in country.Translations) item.AsEntity();
                foreach (var item in country.Demonyms) item.AsEntity();


            }
        }

    }
}
