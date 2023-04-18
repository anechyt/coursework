using Coursework.Infrastructure.MaptilerSearch.Models;

namespace Coursework.Application.NearbySearch.Models
{
    public class LocationRequestModel
    {
        public string ReferenceAddress { get; set; }

        public Location MainLocation { get; set; }

        public int MaxDistance { get; set; }
    }
}
