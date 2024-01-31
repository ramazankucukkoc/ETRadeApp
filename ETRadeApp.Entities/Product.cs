using ETRadeApp.Core.Bases;

namespace ETRadeApp.Entities
{
    public class Product : BaseEntity<int>
    {
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}