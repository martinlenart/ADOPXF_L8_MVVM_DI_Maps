using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;

using Hierarchical.MVVM.Services;
using Hierarchical.Models;
using Hierarchical.Services;

namespace Hierarchical.Simple.Views
{
    public partial class Content2Page : ContentPage
    {
        IGeoLocationService _geoLocationService;

        GeoLocation _geoLocation = null;
        public GeoLocation CurrentGeoLocation
        {
            get => _geoLocation;
            private set
            {
                _geoLocation = value;
                OnPropertyChanged("CurrentGeoLocation");
            }
        }

        public Content2Page()
        {
            InitializeComponent();
            BindingContext = this;
            _geoLocationService = DependencyService.Get<IGeoLocationService>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            CurrentGeoLocation = await _geoLocationService.GetGeoLocationAsync();
 
            //Using the Maps app
            //https://docs.microsoft.com/en-us/xamarin/essentials/maps?context=xamarin%2Fandroid&tabs=uwp
            await NavigateToPosition(CurrentGeoLocation);
        }
        public async Task NavigateToPosition(GeoLocation loc)
        {
            var location = new Location(loc.Latitude, loc.Longitude);
            var options = new MapLaunchOptions { Name = "My position" };

            //Open the separate application
            await Map.OpenAsync(location, options);
        }

        private async void Button_Clicked_Next(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Content3Page());
        }

        private async void Button_Clicked_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}