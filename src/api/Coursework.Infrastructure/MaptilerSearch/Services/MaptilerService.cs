using Coursework.Infrastructure.MaptilerSearch.Abstract;
using Coursework.Infrastructure.MaptilerSearch.Models;
using Coursework.Infrastructure.MaptilerSearch.Options;
using Microsoft.Extensions.Options;

namespace Coursework.Infrastructure.MaptilerSearch.Services
{
    public class MaptilerService : IMaptilerService
    {
        private readonly IOptionsSnapshot<MaptilerOptions> _maptilerOptions;
        private readonly string _subscriptionKey;
        private readonly string _searchUrl;

        public MaptilerService(IOptionsSnapshot<MaptilerOptions> maptilerOptions)
        {
            _maptilerOptions = maptilerOptions;

            _subscriptionKey = _maptilerOptions.Value.SubscriptionKey;
            _searchUrl = _maptilerOptions.Value.SearchUrl;
        }

        public async Task<AddressDataResponseModel> GetDataByAddress(string address, CancellationToken cancellationToken)
        {
            AddressDataResponseModel addressResponseModel = null;

            var requestUri = _searchUrl + $"{address}.json" + "?key=" + _subscriptionKey;

            using var client = new HttpClient();

            var getResponse = await client.GetAsync(new Uri(requestUri), cancellationToken);

            if (!getResponse.IsSuccessStatusCode)
                return addressResponseModel;

            addressResponseModel = await getResponse.Content.ReadAsAsync<AddressDataResponseModel>(cancellationToken);

            return addressResponseModel;
        }
    }
}
