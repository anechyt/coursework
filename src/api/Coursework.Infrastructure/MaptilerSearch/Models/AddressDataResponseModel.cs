using Newtonsoft.Json;

namespace Coursework.Infrastructure.MaptilerSearch.Models
{
    public class AddressDataResponseModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }

        [JsonProperty("features")]
        public List<ResultsResponseModel> Features { get; set; }

        [JsonProperty("query")]
        public List<string> Query { get; set; }
    }

    public class ResultsResponseModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("properties")]
        public Property Properties { get; set; }

        [JsonProperty("place_name")]
        public string PlaceName { get; set; }

        [JsonProperty("relevance")]
        public double Relevance { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("context")]
        public List<Context> Contexts { get; set; }

        [JsonProperty("bbox")]
        public List<double> Bbox { get; set; }

        [JsonProperty("center")]
        public List<double> Center { get; set; }

        [JsonProperty("place_type")]
        public List<string> PlaceType { get; set; }
    }

    public class Property
    {
        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("osm:place_type")]
        public string PlaceType { get; set; }
    }

    public class Location
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }

    public class Context
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
