using Microsoft.Extensions.DependencyInjection;

namespace MaksimShimshon.RestCountries.Embedded
{
    public static class RegisterServiceExtensions
    {
        public static IServiceCollection AddRestCountriesServices(this IServiceCollection serviceCollection, string jsonString)
        {
            serviceCollection.AddSingleton<IRestCountries>(p => new RestCountries(jsonString));
            return serviceCollection;
        }
    }
}
