using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Response
{
    public class LocationResponseModel
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postcode")]
        public int Postcode { get; set; }

        [JsonProperty("coordinates")]
        public CoordinatesResponseModel Coordinates { get; set; }

        [JsonProperty("timezone")]
        public TimezoneResponseModel Timezone { get; set; }
    }
}
