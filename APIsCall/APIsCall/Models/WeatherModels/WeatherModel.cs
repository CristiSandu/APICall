using Newtonsoft.Json;

namespace APIsCall.Models.WeatherModels;

public class WeatherModel
{
    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("current")]
    public Current Current { get; set; }
}
