using Asp.Versioning.ApiExplorer;
using System.Reflection;

namespace Juntos.SomosMais.Challenge.API.Configuration
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        public static void UseSwaggerAndVersionsUI(this IApplicationBuilder app, IApiVersionDescriptionProvider apiVersion)
        {
            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersion.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
}
