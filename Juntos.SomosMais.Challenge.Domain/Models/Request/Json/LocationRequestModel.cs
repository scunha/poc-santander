using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Request.Json
{
    public class LocationRequestModel
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postcode")]
        public int Postcode { get; set; }

        [JsonProperty("coordinates")]
        public CoordinatesRequestModel Coordinates { get; set; }

        [JsonProperty("timezone")]
        public TimezoneRquestModel Timezone { get; set; }
    }
}
