using ETRadeApp.Business.Dtos.Bases;

namespace ETRadeApp.Business.Dtos.Product
{
    public class ResponseProductAddDto : BaseEntityDto<int>
    {
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
