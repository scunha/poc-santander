using Juntos.SomosMais.Challenge.Domain.Models.Request.Json;

namespace Juntos.SomosMais.Challenge.Domain.Interfaces.Services
{
    public interface IHelperService
    {
        List<T> ReadCsvByStream<T>(Stream file);
        Stream ReadByPathUrl(string url);
        T ReadJsonByStream<T>(Stream file);
    }
}
