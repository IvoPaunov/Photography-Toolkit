namespace PhotographyToolkit.UI.WUP.ViewModels
{
    using System;

    public class SunSetRiseResultViewModel : BaseViewModel
    {
        private DateTime date;
        private DateTime sunset;
        private DateTime sunrise;
        private double latitude;
        private double longitude;
        private string city;
        private string country;

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                this.date = value;
                this.OnPropertyChanged("Date");
            }
        }

        public DateTime Sunset
        {
            get { return this.sunset; }
            set
            {
                this.sunset = value;
                this.OnPropertyChanged("Sunset");
            }
        }

        public DateTime Sunrise
        {
            get { return this.sunrise; }
            set
            {
                this.sunrise = value;
                this.OnPropertyChanged("Sunrise");
            }
        }

        public double Latitude
        {
            get { return this.latitude; }
            set
            {
                this.latitude = value;
                this.OnPropertyChanged("Latitude");
            }
        }

        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                this.longitude = value;
                this.OnPropertyChanged("Longitude");
            }
        }

        public string City
        {
            get { return this.city; }
            set
            {
                this.city = value;
                this.OnPropertyChanged("City");
            }
        }

        public string Country
        {
            get { return this.country; }
            set
            {
                this.country = value;
                this.OnPropertyChanged("Country");
            }
        }
    }
}
