namespace PhotographyToolkit.Tools.SunsetAndSunriseService.Models
{
    using System;
    using Newtonsoft.Json;

    public class SunSetRiseResults
    {
        [JsonProperty(PropertyName = "sunrise")]
        public DateTime Sunrise { get; set; }

        [JsonProperty(PropertyName = "sunset")]
        public DateTime Sunset { get; set; }

        [JsonProperty(PropertyName = "solar_noon")]
        public DateTime SolarNoon { get; set; }

        [JsonProperty(PropertyName = "day_length")]
        public int DayLength { get; set; }

        [JsonProperty(PropertyName = "civil_twilight_begin")]
        public DateTime CivilTwilightBegin { get; set; }

        [JsonProperty(PropertyName = "civil_twilight_end")]
        public DateTime CivilTwilightEnd { get; set; }

        [JsonProperty(PropertyName = "nautical_twilight_begin")]
        public DateTime NauticalTwilightBegin { get; set; }

        [JsonProperty(PropertyName = "nautical_twilight_end")]
        public DateTime NauticalTwilightEnd { get; set; }

        [JsonProperty(PropertyName = "astronomical_twilight_begin")]
        public DateTime AstronomicalTwilightBegin { get; set; }

        [JsonProperty(PropertyName = "astronomical_twilight_end")]
        public DateTime AstronomicallTwilightEnd { get; set; }
    }
}
