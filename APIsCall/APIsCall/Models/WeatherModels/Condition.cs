﻿using Newtonsoft.Json;

namespace APIsCall.Models.WeatherModels;

public class Condition
{
    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("icon")]
    public string Icon { get; set; }

    [JsonProperty("code")]
    public int Code { get; set; }
}
