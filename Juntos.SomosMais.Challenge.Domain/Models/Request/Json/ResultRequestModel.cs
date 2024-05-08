using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Request.Json
{
    public class ResultRequestModel
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public NameRequestModel Name { get; set; }

        [JsonProperty("location")]
        public LocationRequestModel Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dob")]
        public DobRequestModel Dob { get; set; }

        [JsonProperty("registered")]
        public RegisteredRequestModel Registered { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("picture")]
        public PictureRequestModel Picture { get; set; }
    }
}
