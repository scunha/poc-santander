using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Response
{
    public class CoordinatesResponseModel
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
