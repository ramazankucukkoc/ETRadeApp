namespace ETRadeApp.Core.DataAccess
{
    public class PagedResult<T> where T : class
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
    }
}
