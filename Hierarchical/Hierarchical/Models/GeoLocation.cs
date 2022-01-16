using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms.Maps;

namespace Hierarchical.Models
{
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Position ToPosition => new Position(Latitude, Longitude);
    }
}
