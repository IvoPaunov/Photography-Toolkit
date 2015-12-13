namespace PhotographyToolkit.Tools.SunsetAndSunriseService.Models
{
    using System;
    using Newtonsoft.Json;

    public class ResultModel
    {
        [JsonProperty(PropertyName = "results")]
        public SunSetRiseResults SunSetRiseResults { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

    }
}
