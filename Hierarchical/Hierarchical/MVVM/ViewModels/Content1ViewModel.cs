using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

using Hierarchical.MVVM.Services;
using Hierarchical.Models;
using Hierarchical.Services;

namespace Hierarchical.MVVM.ViewModels
{
    public class Content1ViewModel : BaseViewModel
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

        public Command NextPage => new Command(async () => await NavigationService.NavigateTo<Content2ViewModel>());
        public Command BackPage => new Command(async () => await NavigationService.GoBack());

        //Services are injected, i.e. Dependency Injection
        public Content1ViewModel(INaviService naviService, IGeoLocationService geoLocationService) : base(naviService)
        {
            //Code for creating the ViewModel
            _geoLocationService = geoLocationService;
        }

        public override async void Init()
        {
            //Code for initialize the ViewModel
 
            //Normally hanlde error via try - catch
            CurrentGeoLocation = await _geoLocationService.GetGeoLocationAsync();
        }
    }
}
