using Hierarchical.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchical.Services
{
    public interface IGeoLocationService
    {
        Task<GeoLocation> GetGeoLocationAsync();
    }
}
