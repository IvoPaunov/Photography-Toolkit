namespace PhotographyToolkit.UI.WUP.Controls
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class CompassControl : Control
    {
        private Windows.Devices.Sensors.Compass compass;

        public CompassControl()
        {
            this.DefaultStyleKey = typeof(CompassControl);

            this.Loaded += this.CompassControl_Loaded;
            this.Unloaded += this.CompassControl_Unloaded;
        }
        

        public static readonly DependencyProperty HeadingProperty = DependencyProperty.Register("Heading",
            typeof(double), typeof(CompassControl), new PropertyMetadata(0.0));

        public double Heading
        {
            get
            {
                return (double)this.GetValue(HeadingProperty);
            }
            set
            {
                this.SetValue(HeadingProperty, value);
            }
        }
        
        private void CompassControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.compass = Windows.Devices.Sensors.Compass.GetDefault();
            if (this.compass != null)
            {
                this.compass.ReadingChanged += this.CompassReadingChanged;
            }
        }

        private void CompassControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this.compass != null)
            {
                this.compass.ReadingChanged -= this.CompassReadingChanged;
            }
        }

        private async void CompassReadingChanged(Windows.Devices.Sensors.Compass sender, Windows.Devices.Sensors.CompassReadingChangedEventArgs args)
        {
            try
            {
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(() =>
                {
                    this.Heading = args.Reading.HeadingMagneticNorth;
                }));
            }
            catch { }
        }
    }
}
