using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Request.Json
{
    public class CoordinatesRequestModel
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
