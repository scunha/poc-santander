using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Response
{
    public class TimezoneResponseModel
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
