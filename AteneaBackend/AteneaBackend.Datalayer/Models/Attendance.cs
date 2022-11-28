namespace AteneaBackend.Datalayer.Models
{
    public class Attendance : BaseModel
    {
        public int StudentId { get; set; }
        public bool IsPresent { get; set; }
        public string? Justification { get; set; }

        // Relationships
        public Student? Student { get; set; }
    }
}
