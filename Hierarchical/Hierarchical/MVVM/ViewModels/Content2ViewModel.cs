using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;

using Hierarchical.MVVM.Services;
using Hierarchical.Models;
using Hierarchical.Services;

namespace Hierarchical.MVVM.ViewModels
{
    public class Content2ViewModel : BaseViewModel
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

        public Command NextPage => new Command(async () => await NavigationService.NavigateTo<Content3ViewModel>());
        public Command BackPage => new Command(async () => await NavigationService.GoBack());

        //Services are injected, i.e. Dependency Injection
        public Content2ViewModel(INaviService naviService, IGeoLocationService geoLocationService) : base(naviService)
        {
            //Code for creating the ViewModel
            _geoLocationService = geoLocationService;
        }

        public override async void Init()
        {
            //Code for initialize the ViewModel

            //Normally hanlde error via try - catch
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
    }
}
