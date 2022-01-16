using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

using Hierarchical.MVVM.Services;
using Hierarchical.Models;
using Hierarchical.Services;

namespace Hierarchical.MVVM.ViewModels
{
    public class Content3ViewModel : BaseViewModel
    {
        IGeoLocationService _geoLocationService;
        GeoLocation _geoLocation = null;
        Xamarin.Forms.Maps.Map _map = null;

        public GeoLocation CurrentGeoLocation
        {
            get => _geoLocation;
            private set
            {
                _geoLocation = value;
                OnPropertyChanged("CurrentGeoLocation");
            }
        }

        public Command BackPage => new Command(async () => await NavigationService.GoBack());

        //Services are injected, i.e. Dependency Injection
        public Content3ViewModel(INaviService naviService, IGeoLocationService geoLocationService, Xamarin.Forms.Maps.Map map) : base(naviService)
        {
            //Code for creating the ViewModel
            _geoLocationService = geoLocationService;
            _map = map;
        }

        public override async void Init()
        {
            //Code for initialize the ViewModel

            //Normally hanlde error via try - catch
            CurrentGeoLocation = await _geoLocationService.GetGeoLocationAsync();

            //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/map
            //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/setup
            MapSpan mapSpan = new MapSpan(CurrentGeoLocation.ToPosition, 0.01, 0.01);
            _map.MoveToRegion(mapSpan);
        }
    }
}
