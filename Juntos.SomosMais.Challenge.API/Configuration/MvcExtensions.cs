using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Juntos.SomosMais.Challenge.API.Configuration
{
    public static class MvcExtensions
    {
        public static void AddCustomMvc(this IServiceCollection services)
        {
            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.SuppressAsyncSuffixInActionNames = false;
                })
                .AddNewtonsoftJson(options =>
                {
                    options.UseCamelCasing(processDictionaryKeys: true);

                    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver
                        {
                            NamingStrategy = new CamelCaseNamingStrategy
                            {
                                ProcessDictionaryKeys = true
                            }
                        }
                    };
                });

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });
        }
    }
}
