namespace PhotographyToolkit.Tools.SunsetAndSunriseService.Models
{
    using System;

    public class RequestModel
    {
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime? Date { get; set; }
    }
}
