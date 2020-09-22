using System;
using Newtonsoft.Json;

namespace RoofStock.CodingExercise.Api.Models
{
    public class PropertyModel
    {
        [JsonProperty("guid")]
        public Guid? Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("yearBuilt")]
        public int YearBuilt { get; set; }

        [JsonProperty("monthlyRent")]
        public decimal MonthlyRent { get; set; }

        [JsonProperty("listPrice")]
        public decimal ListPrice { get; set; }
    }
}