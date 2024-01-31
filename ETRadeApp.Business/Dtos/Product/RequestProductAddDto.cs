namespace ETRadeApp.Business.Dtos.Product
{
    public class RequestProductAddDto
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
