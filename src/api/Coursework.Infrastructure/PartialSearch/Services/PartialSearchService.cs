using Coursework.Infrastructure.PartialSearch.Abstract;
using Coursework.Infrastructure.PartialSearch.Models;

namespace Coursework.Infrastructure.PartialSearch.Services
{
    public class PartialSearchService : IPartialSearchService
    {
        public int PartialSearch(PartialSearchModel searchModel)
        {
            var numberOfMatches = 0;

            foreach (var request in searchModel.Requests)
            {
                foreach(var searchItem in searchModel.SearchList)
                {
                    double similarity = CalculateJaccardSimilarity(searchItem, request);
                    if (similarity >= 0.6) // Define a threshold for partial match
                    {
                        numberOfMatches += 1;
                    }
                }
            }

            return numberOfMatches;
        }
        private double CalculateJaccardSimilarity(string str1, string str2)
        {
            HashSet<char> set1 = new HashSet<char>(str1);
            HashSet<char> set2 = new HashSet<char>(str2);

            int intersectionCount = set1.Intersect(set2).Count();
            int unionCount = set1.Count + set2.Count - intersectionCount;

            double similarity = (double)intersectionCount / unionCount;
            return similarity;
        }
    }
}
