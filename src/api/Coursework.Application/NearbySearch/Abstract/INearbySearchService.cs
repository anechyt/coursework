using Coursework.Application.NearbySearch.Models;

namespace Coursework.Application.NearbySearch.Abstract
{
    public interface INearbySearchService
    {
        Task<bool> CheckCityInRadius(LocationRequestModel locationRequestModel, CancellationToken cancellationToken);
    }
}
