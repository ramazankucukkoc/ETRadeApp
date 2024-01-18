using ETRadeApp.Core.Bases;

namespace ETRadeApp.Entities
{
    public class Category : BaseEntity<int>
    {
        public ICollection<Product> Products { get; set; }
    }
}
