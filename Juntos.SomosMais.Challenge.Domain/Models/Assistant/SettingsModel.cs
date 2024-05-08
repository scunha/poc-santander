using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juntos.SomosMais.Challenge.Domain.Models.Assistant
{
    public class SettingsModel
    {
        public SettingsModel()
        {
            UrlCsv = string.Empty;
            UrlJson = string.Empty;
        }

        [JsonProperty("urlCsv")]
        public string UrlCsv { get; set; }
            

        [JsonProperty("urlJson")]
        public string UrlJson { get; set; }
    }
}
