namespace AteneaBackend.Datalayer.Models
{
    public class Teacher : BaseModel
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Relationships
        public List<Student>? Students { get; set; }
    }
}
