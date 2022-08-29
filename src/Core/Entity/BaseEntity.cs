namespace Core.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
