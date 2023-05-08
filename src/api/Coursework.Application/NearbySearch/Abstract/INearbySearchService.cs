using Coursework.Application.NearbySearch.Models;
using Coursework.Infrastructure.MaptilerSearch.Models;

namespace Coursework.Application.NearbySearch.Abstract
{
    public interface INearbySearchService
    {
        Task<bool> CheckCityInRadius(LocationRequestModel locationRequestModel, CancellationToken cancellationToken);

        Task<Location> GetLocationByAddress(string address, CancellationToken cancellationToken);
    }
}
