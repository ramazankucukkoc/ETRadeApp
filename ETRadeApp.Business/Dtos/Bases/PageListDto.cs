namespace ETRadeApp.Business.Dtos.Bases
{
    public class PageListDto<T>
        where T : class
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
    }
}
