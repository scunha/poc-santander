using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Request.Json
{
    public class PictureRequestModel
    {
        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
