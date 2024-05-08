using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Response
{
    public class NameResponseModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }
    }
}
