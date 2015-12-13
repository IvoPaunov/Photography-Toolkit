namespace PhotographyToolkit.UI.WUP.ViewModels
{
    using System;
    using System.Runtime.InteropServices.ComTypes;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using PhotographyToolkit.Tools.SunsetAndSunriseService;
    using PhotographyToolkit.UI.WUP.Commands;
    using PhotographyToolkit.UI.WUP.Helpers.Geolocator;
    using Windows.Devices.Geolocation;

    public class SunsetSunriseViewModel : BaseViewModel
    {
        private SunsetAndSunriseService sunSetRiseService;
        private SunSetRiseResultViewModel sunSetRiseResultViewModel;
        private GeoLocatorHelper geoLocatorHelper;

        private ICommand getSunSetRiseInfoCommand;

        private bool waitingForLocation = true;

        public SunsetSunriseViewModel()
        {
            this.sunSetRiseService = new SunsetAndSunriseService();
            this.geoLocatorHelper = new GeoLocatorHelper();
            this.HandleGetSunSetRiseInfoCommand();
        }

        public ICommand GetSunSetRiseInfo
        {
            get
            {
                if (this.getSunSetRiseInfoCommand == null)
                {
                    this.getSunSetRiseInfoCommand = new RelayCommand(this.HandleGetSunSetRiseInfoCommand);
                }

                return this.getSunSetRiseInfoCommand;
            }
        }

        private async void HandleGetSunSetRiseInfoCommand()
        {
            this.WaitingForLocation = true;

            var accessStatus = await Geolocator.RequestAccessAsync();

            var result = await this.geoLocatorHelper.HandeleAccessStatus(accessStatus);

            if (result != null)
            {
               // Task.Delay(2000).Wait();

                var latitude = result.Coordinate.Latitude;
                var longtutude = result.Coordinate.Longitude;

                this.WaitingForLocation = false;

                var sunResult = await this.sunSetRiseService.GetSunsetAndSunriseTimes(
                    latitude,
                    longtutude,
                    //this.SunResult.Latitude,
                    //this.SunResult.Longitude,
                    this.SunResult.Date);

                    this.SunResult.Longitude = result.Coordinate.Latitude;
                    this.SunResult.Latitude = result.Coordinate.Latitude;

                this.SunResult.Sunrise = sunResult.Sunrise;
                this.SunResult.Sunset = sunResult.Sunset;

                var address = await geoLocatorHelper.GetCivilAddresByLocation(latitude, longtutude);

                if (address != null)
                {
                    this.SunResult.City = address.Town;
                    this.SunResult.Country = address.Country;
                }
            }
        }

        public SunSetRiseResultViewModel SunResult
        {
            get
            {
                if (this.sunSetRiseResultViewModel == null)
                {
                    this.sunSetRiseResultViewModel = new SunSetRiseResultViewModel() { Date = DateTime.Now };
                }

                return this.sunSetRiseResultViewModel;
            }
            set
            {
                this.sunSetRiseResultViewModel = value;
                this.OnPropertyChanged("SunResult");
            }
        }

        public bool WaitingForLocation
        {
            get { return this.waitingForLocation; }
            set
            {
                this.waitingForLocation = value;
                this.OnPropertyChanged("WaitingForLocation");
            }
        }
    }
}
