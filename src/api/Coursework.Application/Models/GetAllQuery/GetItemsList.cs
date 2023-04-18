namespace Coursework.Application.Models.GetAllQuery
{
    public class GetItemsList<T> where T : class
    {
        public List<T> Items { get; set; }
    }
}
