using Newtonsoft.Json;

namespace RichestCountries.Models
{
    public class Region
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("iso2code")]
        public string Iso2Code { get; set; }

        [JsonProperty("value")]
        public string Name { get; set; }
    }
}