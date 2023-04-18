using Coursework.Infrastructure.MaptilerSearch.Models;

namespace Coursework.Infrastructure.MaptilerSearch.Abstract
{
    public interface IMaptilerService
    {
        Task<AddressDataResponseModel> GetDataByAddress(string address, CancellationToken cancellationToken);
    }
}
