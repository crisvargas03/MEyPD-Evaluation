namespace AteneaBackend.Datalayer.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
