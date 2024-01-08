namespace ETRadeApp.Core.Bases
{
    public class BaseEntity<I> where I : struct
    {
        public BaseEntity()
        {
        }
        public BaseEntity(I id) : this()
        {
            Id = id;
        }
        public I Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
