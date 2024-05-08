using Juntos.SomosMais.Challenge.Domain.Interfaces.Services;
using Juntos.SomosMais.Challenge.Domain.Models.Assistant;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Juntos.SomosMais.Challenge.Service.Services.Middlewares
{   
    public class InitialLoadService(ILogger<InitialLoadService> logger, IChallengeService challengeService, SettingsModel settings) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.Run(async () =>
            {
                await RunInicialLoadAsync();

            }, stoppingToken);

            return Task.CompletedTask;
        }

        private async Task RunInicialLoadAsync()
        {
            try
            {
                logger.LogInformation($"Iniciando rotina de carga Inicial");

                var urlCsv = settings.UrlCsv;
                var urlJson = settings.UrlJson;

                await challengeService.InitialLoad(urlCsv, urlJson);

                logger.LogInformation($"Fim da rotina de carga Inicial");

            }catch (Exception ex)
            {
                throw new Exception("Houve um erro na carga inicial", ex);
            }
        }

        
    }
}
