using ETRadeApp.Core.Bases;

namespace ETRadeApp.Entities
{
    public class Category : BaseEntity<int>
    {
        public List<Product> Products { get; set; }
    }
}
