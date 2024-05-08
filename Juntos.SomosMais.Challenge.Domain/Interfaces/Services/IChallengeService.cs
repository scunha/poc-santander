using Juntos.SomosMais.Challenge.Domain.Models.Response;

namespace Juntos.SomosMais.Challenge.Domain.Interfaces.Services
{
    public interface IChallengeService
    {
        Task<bool> InitialLoad(string urlCsv, string urlJson);
        ResultResponseModel GetListPagination(string region, string type, int pageNumber, int pageSize);
    }
}