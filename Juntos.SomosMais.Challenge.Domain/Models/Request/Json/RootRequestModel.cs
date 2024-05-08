using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Request.Json
{
    public class RootRequestModel
    {
        [JsonProperty("results")]
        public List<ResultRequestModel> Results { get; set; }
    }
}
