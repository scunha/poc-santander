using Newtonsoft.Json;

namespace Juntos.SomosMais.Challenge.Domain.Models.Assistant
{
    public class ClassificationCoordinatesModel
    {
        #region Especial 1
        [JsonProperty("minLatEsp1")]
        public double MinLatEsp1 = -46.361899;

        [JsonProperty("minLonEsp1")]
        public double MinLonEsp1 = -2.196998;

        [JsonProperty("maxLatEsp1")]
        public double MaxLatEsp1 = -34.276938;

        [JsonProperty("maxLonEsp1")]
        public double MaxLonEsp1 = -15.411580;
        #endregion

        #region Especial 2
        [JsonProperty("minLatEsp2")]
        public double MinLatEsp2 = -52.997614;

        [JsonProperty("minLonEsp2")]
        public double MinLonEsp2 = -19.766959;

        [JsonProperty("maxLatEsp2")]
        public double MaxLatEsp2 = -44.428305;

        [JsonProperty("maxLonEsp2")]
        public double MaxLonEsp2 = -23.966413;
        #endregion


        #region Normal
        [JsonProperty("minLatNormal")]
        public double MinLatNormal = -54.777426;

        [JsonProperty("minLonNormal")]
        public double MinLonNormal = -26.155681;

        [JsonProperty("maxLatNormal")]
        public double MaxLatNormal = -46.603598;

        [JsonProperty("maxLonNormal")]
        public double MaxLonNormal = -34.016466;
        #endregion
    }
}
