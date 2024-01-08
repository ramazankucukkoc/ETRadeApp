namespace ETRadeApp.Business.Dtos.Bases
{
    public class BaseEntityDto<T>
        where T : struct
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
