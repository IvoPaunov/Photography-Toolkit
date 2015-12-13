namespace PhotographyToolkit.UI.WUP.Helpers.Geolocator
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using NotificationsExtensions.Toasts;

    using PhotographyToolkit.UI.WUP.Helpers.ToastNotifications;

    using Windows.Devices.Geolocation;
    using Windows.Services.Maps;
    using Windows.UI.Notifications;

    public class GeoLocatorHelper
    {
        public async Task<Geoposition> HandeleAccessStatus(  GeolocationAccessStatus accessStatus)
        {
            ToastVisual visual = null;
            Geoposition geoposition = null;

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 1000 };
                    geoposition = await geolocator.GetGeopositionAsync();
                    break;

                case GeolocationAccessStatus.Denied:
                    visual = ToastCrerator.GetVisualToast("Access to location is denied.", null, null);
                    break;

                case GeolocationAccessStatus.Unspecified:
                    visual = ToastCrerator.GetVisualToast("Unspecified error.", null, null);
                    break;
            }

            if (visual != null)
            {
                var button = new ToastButtonDismiss();
                ToastActionsCustom actios = ToastCrerator.GetToastCustomActions(null, new List<IToastButton>() { button });
                ToastContent content = ToastCrerator.GetToastContent(visual, actios);
                var doc = content.GetXml();
                var notification = new ToastNotification(doc);
                ToastNotificationManager.CreateToastNotifier().Show(notification);
            }

            return geoposition;
        }

        public async Task<MapAddress> GetCivilAddresByLocation(double latitude, double longtitude)
        {
            BasicGeoposition location = new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longtitude
            };

            Geopoint pointToReverseGeocode = new Geopoint(location);

            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            MapAddress addres = null; 

            if (result != null && result.Locations != null && result.Locations.Count > 0)
            {
                addres = result.Locations[0].Address;
            }

            return addres;
        }
    }
}
