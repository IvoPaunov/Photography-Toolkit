namespace PhotographyToolkit.Tools.SunsetAndSunriseService.Models
{
    using System;

    public class SunSetRiseRequestModel
    {
        public SunSetRiseRequestModel(double latitude, double longtitude, DateTime? date)
        {
            this.Latitude = latitude;
            this.Longitude = longtitude;
            this.Date = date;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime? Date { get; set; }
    }
}
