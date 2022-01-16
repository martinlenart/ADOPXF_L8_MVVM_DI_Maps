using System;
using Xamarin.Forms;

using Hierarchical.Services;
using Hierarchical.Models;

namespace Hierarchical.Simple.Views
{
    public partial class Content1Page : ContentPage
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

        public Content1Page()
        {
            InitializeComponent();
            BindingContext = this;
            _geoLocationService = DependencyService.Get<IGeoLocationService>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            CurrentGeoLocation = await _geoLocationService.GetGeoLocationAsync();
        }


        private async void Button_Clicked_Next(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Content2Page());
        }

        private async void Button_Clicked_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}