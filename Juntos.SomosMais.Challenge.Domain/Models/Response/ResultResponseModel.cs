using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Juntos.SomosMais.Challenge.Domain.Models.Response
{
    public class ResultResponseModel
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("totalPage")]
        public int TotalPage { get; set; }

        [JsonProperty("users")]
        public List<RootResponseModel> Users { get; set; }
    }
}
