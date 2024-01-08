using ETRadeApp.Core.Bases;

namespace ETRadeApp.Business.Dtos.Product
{
    public class ResponseProductAddDto:BaseEntity<int>
    {
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
