using Coursework.Infrastructure.PartialSearch.Models;

namespace Coursework.Infrastructure.PartialSearch.Abstract
{
    public interface IPartialSearchService
    {
        int PartialSearch(PartialSearchModel searchModel);
    }
}
