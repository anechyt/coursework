namespace Coursework.Infrastructure.MaptilerSearch.Options
{
    public class MaptilerOptions
    {
        public static string SectionName => "MaptilerApi";

        public string SubscriptionKey { get; set; }

        public string SearchUrl { get; set; }
    }
}
