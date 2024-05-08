using Newtonsoft.Json;


namespace Juntos.SomosMais.Challenge.Domain.Models.Request.Csv
{
    public class ExcelRequestModel
    {

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("nameTitle")]
        public string name__title { get; set; }

        [JsonProperty("nameFirst")]
        public string name__first { get; set; }

        [JsonProperty("nameLast")]
        public string name__last { get; set; }

        [JsonProperty("locationStreet")]
        public string location__street { get; set; }

        [JsonProperty("locationCity")]
        public string location__city { get; set; }

        [JsonProperty("locationState")]
        public string location__state { get; set; }

        [JsonProperty("locationPostcode")]
        public int location__postcode { get; set; }

        [JsonProperty("locationCoordinatesLatitude")]
        public double location__coordinates__latitude { get; set; }

        [JsonProperty("locationCoordinatesLongitude")]
        public double location__coordinates__longitude { get; set; }

        [JsonProperty("locationTimezoneOffset")]
        public string location__timezone__offset { get; set; }

        [JsonProperty("locationTimezoneDescription")]
        public string location__timezone__description { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("dobDate")]
        public DateTime dob__date { get; set; }

        [JsonProperty("dobAge")]
        public int dob__age { get; set; }

        [JsonProperty("registeredDate")]
        public DateTime registered__date { get; set; }

        [JsonProperty("registeredAge")]
        public int registered__age { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonProperty("cell")]
        public string cell { get; set; }

        [JsonProperty("pictureLarge")]
        public string picture__large { get; set; }

        [JsonProperty("pictureMedium")]
        public string picture__medium { get; set; }

        [JsonProperty("pictureThumbnail")]
        public string picture__thumbnail { get; set; }
    }
}
