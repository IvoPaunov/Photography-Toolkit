namespace PhotographyToolkit.UI.WUP.Views
{
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SunsetSunriseView : Page
    {
        public SunsetSunriseView()
        {
            this.InitializeComponent();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(
                typeof(BasicSubPage),
                e.ClickedItem,
                new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());

            // DrillInNavigationTransitionInfo
            // ContinuumNavigationTransitionInfo
        }
    }
}
