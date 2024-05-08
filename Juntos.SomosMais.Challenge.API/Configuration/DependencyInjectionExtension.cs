using AutoMapper;
using Juntos.SomosMais.Challenge.Domain.Interfaces.Repositories;
using Juntos.SomosMais.Challenge.Domain.Interfaces.Services;
using Juntos.SomosMais.Challenge.Domain.Models.Assistant;
using Juntos.SomosMais.Challenge.Infra.Repositories;
using Juntos.SomosMais.Challenge.Service.Services;
using Microsoft.Extensions.Options;

namespace Juntos.SomosMais.Challenge.API.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<SettingsModel>(config.GetSection("Appsettings"));
            services.AddSingleton(provider => provider.GetRequiredService<IOptions<SettingsModel>>().Value);

            
            #region Repositories
            services.AddSingleton<IChallengeRepository, ChallengeRepository>();
            #endregion

            #region Services
            services.AddSingleton<IHelperService, HelperService>();
            services.AddSingleton<IChallengeService, ChallengeService>();
            #endregion


        }
    }
}
