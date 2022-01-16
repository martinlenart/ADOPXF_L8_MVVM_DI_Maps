using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

using Hierarchical.Models;

//Registering the dependency. Xamarin.Forms Dependency maps Implementation - Interface via reflection
using Hierarchical.Services;
[assembly: Dependency(typeof(GeoLocationService))]

namespace Hierarchical.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        public async Task<GeoLocation> GetGeoLocationAsync()
        {
            //Using Xamarin Esentials implementation
            //Set Platfrom access rights
            //https://docs.microsoft.com/en-us/xamarin/essentials/geolocation?tabs=android
            var geo = await Geolocation.GetLocationAsync();

            return new GeoLocation { Latitude = geo.Latitude, Longitude = geo.Longitude };
        }
    }
}
