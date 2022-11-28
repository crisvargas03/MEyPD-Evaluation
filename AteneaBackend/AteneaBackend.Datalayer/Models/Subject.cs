namespace AteneaBackend.Datalayer.Models
{
    public class Subject : BaseModel
    {
        public string? Name { get; set; }

        // Relationships
        public List<GradesBook>? GradesBooks { get; set; }
    }
}
