using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Request.Json
{
    public class DobRequestModel
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
