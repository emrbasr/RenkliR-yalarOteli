namespace RenkliRüyalarOteli.Entities.Entities.Abstract
{
    public enum Status
    {
        Active = 1,
        Update = 2,
        Delete = 3

    }
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; } = Status.Active;

    }
}
