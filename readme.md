[![License: MPL 2.0](https://img.shields.io/badge/License-MPL_2.0-brightgreen.svg)](https://opensource.org/licenses/MPL-2.0)
[![NuGet Version](https://img.shields.io/nuget/v/MaksimShimshon.RestCountries)](https://www.nuget.org/packages/MaksimShimshon.RestCountries)
[![](https://img.shields.io/nuget/dt/MaksimShimshon.RestCountries?label=Downloads)](https://www.nuget.org/packages/MaksimShimshon.RestCountries)
[![Build](https://github.com/mshimshon/MaksimShimshon.RestCountries/actions/workflows/ci.yml/badge.svg)](https://github.com/mshimshon/MaksimShimshon.RestCountries/actions/workflows/ci.yml)
[![Deploy](https://github.com/mshimshon/MaksimShimshon.RestCountries/actions/workflows/deploy.yml/badge.svg)](https://github.com/mshimshon/MaksimShimshon.RestCountries/actions/workflows/deploy.yml)
# 🌍 RestCountries C# Port

This C# library is a full port of the REST Countries Java API, preserving full compatibility with the original JSON structure (v3.1 and v3).

It provides strongly typed access to rich country and region data, ideal for .NET developers building apps that need detailed country-related information.

The package supports dependency injection for seamless integration into modern web applications. 

It also includes high test coverage, making it production-ready.


## 🔑 Key Features

- Access detailed country data: name, capital, region, population, area, and more
- Retrieve languages, currencies, and translations of country names
- Time zone support for all countries
- Strongly typed models for easy C# integration
- Fully compatible with original REST Countries JSON formats
- Built-in support for ASP.NET dependency injection


Perfect for apps that need reliable, structured, and localized country information.

## Important Information
* We are supporting [REST Countries Java] (Alejandro Matos) Version 3, Version 3.1 and plan the maintain compatibility.
* ***Versions will be updated according to [REST Countries Java] version updates.***
* ***Consider contribution to the JSON data for [REST Countries Java].***
## Pakages
### [MaksimShimshon.RestCountries](https://www.nuget.org/packages/MaksimShimshon.RestCountries)

[![](https://img.shields.io/nuget/v/MaksimShimshon.RestCountries?label=Latest)](https://www.nuget.org/packages/MaksimShimshon.RestCountries) 
[![](https://img.shields.io/nuget/dt/MaksimShimshon.RestCountries?label=Downloads)](https://www.nuget.org/packages/MaksimShimshon.RestCountries)

This .NET 8 based pakage contains the core behaviour for the RestCountries without any dependencies.
``` cs
using MaksimShimshon.RestCountries;
using MaksimShimshon.RestCountries.Data;
var builder = WebApplication.CreateBuilder(args);
// this will make a singleton accessible through IRestCountries.
// replace RestCountriesEmbed.GetVersion("countriesV3.1") by your local or remote verson.json file.
builder.Services.AddRestCountriesServices(RestCountriesEmbed.GetVersion());
```

### [MaksimShimshon.RestCountries.Embedded](https://www.nuget.org/packages/MaksimShimshon.RestCountries.Embedded)

[![](https://img.shields.io/nuget/v/MaksimShimshon.RestCountries.Embedded?label=Latest)](https://www.nuget.org/packages/MaksimShimshon.RestCountries.Embedded)
[![](https://img.shields.io/nuget/dt/MaksimShimshon.RestCountries?label=Downloads)](https://www.nuget.org/packages/MaksimShimshon.RestCountries)

> 📦 **Package Size Consideration**

The `Embedded` package includes **all available JSON versions**, which significantly increases its size.  
This may not be suitable for **front-end deployments** due to payload concerns.

However, it is ideal for **server-side use**, where having access to multiple versions of the data can be valuable.


``` cs
using MaksimShimshon.RestCountries;
using MaksimShimshon.RestCountries.Embedded;
var builder = WebApplication.CreateBuilder(args);
// this will make a singleton accessible through IRestCountries.
builder.Services.AddRestCountriesServices(RestCountriesEmbed.GetVersion("countriesV3.1"));

```

### [MaksimShimshon.RestCountries.Data](https://www.nuget.org/packages/MaksimShimshon.RestCountries.Data)

[![](https://img.shields.io/nuget/v/MaksimShimshon.RestCountries.Data?label=Latest)](https://www.nuget.org/packages/MaksimShimshon.RestCountries.Data) 
[![](https://img.shields.io/nuget/dt/MaksimShimshon.RestCountries.Data?label=Downloads)](https://www.nuget.org/packages/MaksimShimshon.RestCountries.Data)

> ⚠️ **Important Compatibility Notice**

This package **must not** be installed alongside the `MaksimShimshon.RestCountries.Embedded` package.  
A conflict has been intentionally introduced by using the same `RestCountriesEmbed` class in both packages to avoid incompatibility.

- `**Embedded**` includes **all available JSON versions**.
- `**Data**` includes **only the targeted version reflected on the package version**.

As a result, the version of the `Data` package you install will match the version the latest version.


``` cs
using MaksimShimshon.RestCountries;
using MaksimShimshon.RestCountries.Data;
var builder = WebApplication.CreateBuilder(args);
// this will make a singleton accessible through IRestCountries.
builder.Services.AddRestCountriesServices(RestCountriesEmbed.GetVersion());

```

# Fields
You can check the [FIELDS.md](https://github.com/mshimshon/MaksimShimshon.RestCountries/blob/main/fields.md) file to get info on each classes.


## Getting Started

``` cs
using MaksimShimshon.RestCountries.Embedded;

// Replace this to the json content of the version.json or use embeded content.
string jsonContentOfVersion = RestCountriesEmbed.GetVersion("countriesV3.1");
IRestCountries restCountries = new RestCountries(jsonContentOfVersion);
var countries = restCountries.GetAll();

```

## Check if Postal Required
``` cs
using MaksimShimshon.RestCountries.Embedded;

string jsonContentOfVersion = RestCountriesEmbed.GetVersion(version);
IRestCountries restCountries = new RestCountries(jsonContentOfVersion);
var countries = restCountries.GetAll();
var firstCountry = countries.First();
if (firstCountry.IsPostalRequired()) 
    Console.WriteLine($"{firstCountry.Name.Common} does require postal of format: {firstCountry.PostalFormat!.Format}");
else
    Console.WriteLine($"{firstCountry.Name.Common} does not require a postal.");

```

## Fetch Country by ISO-2 & Validate its postal code
``` cs
using MaksimShimshon.RestCountries.Embedded;

string jsonContentOfVersion = RestCountriesEmbed.GetVersion(version);
IRestCountries restCountries = new RestCountries(jsonContentOfVersion);
var countries = restCountries.GetAll();
// ca = Canada. You could also do CCA3 with CAN.
var firstCountry = restCountries.IsValidCCA2Code("ca");
if (restCountries.IsValidCCA2Code("ca"))
    if (restCountries.GetByCCA2Code("cA")!.IsPostalValid("H1A2T2")) 
        Console.WriteLine("H1A2T2 is a valid postal for Canada");
    else
        Console.WriteLine($"ca is not a valid country iso2.");

```

## More to Explore
Explore the other functions
``` cs
using MaksimShimshon.RestCountries.Embedded;

string jsonContentOfVersion = RestCountriesEmbed.GetVersion(version);
IRestCountries restCountries = new RestCountries(jsonContentOfVersion);
var countries = restCountries.GetAll();
if (restCountries.IsValidCCA2Code("ca")) Console.WriteLine("This is valid country code.");
if (restCountries.IsValidCCA3Code("can")) Console.WriteLine("This is valid country code.");
if (restCountries.IsValidCCA2PostalCode("ca", "H1T2S2")) Console.WriteLine("This is valid country code and postal.");
if (restCountries.IsValidCCA3PostalCode("can", "H1T2S2")) Console.WriteLine("This is valid country code and postal.");
if (restCountries.IsValidCCA2Currency("ca", "CAD")) Console.WriteLine("CAD is a valid Canadian Currency.");
if (restCountries.IsValidCCA3Currency("cad", "CAD")) Console.WriteLine("CAD is a valid Canadian Currency.");
if (restCountries.IsValidCCA3Currency("cad", "CAD")) Console.WriteLine("CAD is a valid Canadian Currency.");

var country = countries.First()!;
Console.WriteLine($"Phone Prefixes are {string.Join(',', country.PhonePrefixes())}");
```

## Similar projects
* [REST Countries Java] (original)
* [Countries of the world]
* [REST Countries Node.js]
* [REST Countries Ruby]
* [REST Countries Go]
* [REST Countries Python]
* [world-currencies]

[world-currencies]: https://github.com/wiredmax/world-currencies
[REST Countries Java]: https://gitlab.com/restcountries/restcountries
[REST Countries Node.js]: https://github.com/aredo/restcountries
[REST Countries Ruby]: https://github.com/davidesantangelo/restcountry
[REST Countries Go]: https://github.com/alediaferia/gocountries
[REST Countries Python]: https://github.com/SteinRobert/python-restcountries
[Countries of the world]: http://countries.petethompson.net
[Original Project]: https://github.com/apilayer/restcountries/
[donation]: https://www.paypal.me/amatosg/15
[donate]: https://www.paypal.me/amatosg/15
