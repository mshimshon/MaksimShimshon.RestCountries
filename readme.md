[![License: MPL 2.0](https://img.shields.io/badge/License-MPL_2.0-brightgreen.svg)](https://opensource.org/licenses/MPL-2.0)




# About this Project

**RestCountries C# Port**  

This C# library is a full port of the RestCountries Java API, maintaining full compatibility with the original JSON data (v3.1 & v3) structure from the project.  

The library provides access to comprehensive country and region information, including time zones, languages, currencies, translations, and more.  

The library offers strongly typed access to country data, making it ideal for .NET developers building apps that need country-related information.  

This package is specifically adapted for use with ASP.NET, supporting dependency injection for seamless integration into ASP.NET applications.  

The library uses high code test coverage for production use.  

Key Features:  
- Access country data (name, capital, region, population, area, etc.)  
- Retrieve languages, currencies, and translations of country names.  
- Supports time zone data for each country.  
- Simple integration with C# applications using strongly typed objects.  
- Compatible with original RestCountries JSON data format.  
- Fully supports ASP.NET dependency injection for clean integration into your application.




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

Since Embedded includes all available JSON versions, it increases the package size, which may not be ideal for front-end deployments. 
However, it provides valuable resource files (all available versions) for server-side.

``` cs
using MaksimShimshon.RestCountries;
using MaksimShimshon.RestCountries.Embedded;
var builder = WebApplication.CreateBuilder(args);
// this will make a singleton accessible through IRestCountries.
builder.Services.AddRestCountriesServices(RestCountriesEmbed.GetVersion("countriesV3.1"));

```
### [MaksimShimshon.RestCountries.Data](https://www.nuget.org/packages/MaksimShimshon.RestCountries.Data)
This pakage should not be installed along side Embedded and we've introduced a conflict on purpose (using RestCountriesEmbed as class) due to incompatibility.
Embedded includes all available JSON versions and Data includes only the targeted version.
Which means, the pakage version you have install will match the version available by the original JSON files.

``` cs
using MaksimShimshon.RestCountries;
using MaksimShimshon.RestCountries.Data;
var builder = WebApplication.CreateBuilder(args);
// this will make a singleton accessible through IRestCountries.
builder.Services.AddRestCountriesServices(RestCountriesEmbed.GetVersion());

```

# Fields
You can check the [FIELDS.md](FIELDS.md) file to get info on each classes.


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
