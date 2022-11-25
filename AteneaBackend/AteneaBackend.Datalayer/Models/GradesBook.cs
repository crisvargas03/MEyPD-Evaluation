namespace AteneaBackend.Datalayer.Models
{
    public class GradesBook : BaseModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }

        // Relationships
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
    }
}
