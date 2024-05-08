using Newtonsoft.Json;


namespace Juntos.SomosMais.Challenge.Domain.Models.Response
{
    public class PictureresponseModel
    {
        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
