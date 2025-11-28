using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamenCountries.Model
{
    public class Country
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        [JsonPropertyName("capital")]
        public string Capital { get; set; } = "";
        [JsonPropertyName("region")]
        public string Region { get; set; } = "";
        [JsonPropertyName("population")]
        public string Population { get; set; } = "";
    }
}
