namespace PhotographyToolkit.Tools.SunsetAndSunriseService.Models
{
    using System;
    using Newtonsoft.Json;

    public class ResultModel
    {
        [JsonProperty(PropertyName = "results")]
        public Results Results { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

    }
}
