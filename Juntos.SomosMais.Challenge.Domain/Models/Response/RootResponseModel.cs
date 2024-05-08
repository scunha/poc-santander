using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Response
{
    public class RootResponseModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public NameResponseModel Name { get; set; }

        [JsonProperty("location")]
        public LocationResponseModel Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        [JsonProperty("registered")]
        public DateTime Registered { get; set; }

        [JsonProperty("telephoneNumbers")]
        public List<string> TelephoneNumbers { get; set; }

        [JsonProperty("mobileNumbers")]
        public List<string> MobileNumbers { get; set; }

        [JsonProperty("picture")]
        public PictureresponseModel Picture { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }
    }
}
