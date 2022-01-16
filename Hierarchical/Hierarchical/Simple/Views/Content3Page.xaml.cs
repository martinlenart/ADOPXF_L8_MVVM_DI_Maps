using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

using Hierarchical.MVVM.Services;
using Hierarchical.Models;
using Hierarchical.Services;

namespace Hierarchical.Simple.Views
{
    public partial class Content3Page : ContentPage
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

        public Content3Page()
        {
            InitializeComponent();
            BindingContext = this;
            _geoLocationService = DependencyService.Get<IGeoLocationService>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            CurrentGeoLocation = await _geoLocationService.GetGeoLocationAsync();

            //Using the Xamarin.Forms Map Control
            //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/map
            MapSpan mapSpan = new MapSpan(CurrentGeoLocation.ToPosition, 0.01, 0.01);
            myMap.MoveToRegion(mapSpan);
        }

        private async void Button_Clicked_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}