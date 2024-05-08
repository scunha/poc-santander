using Asp.Versioning;

namespace Juntos.SomosMais.Challenge.API.Configuration
{
    public static class ApiVersioningExtensions
    {
        public static void AddDefaultApiVersioning(this IServiceCollection services)
        {
            var apiVersion = services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            apiVersion.AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
