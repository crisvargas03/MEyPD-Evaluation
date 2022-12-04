namespace AteneaBackend.Datalayer.Models
{
    public class Student : BaseModel
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string? CardnetNumber { get; set; }
        public string? Condition { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int TeacherId { get; set; }

        // Relationships
        public Teacher? Teacher { get; set; }
        public List<GradesBook>? GradesBooks { get; set; }
        public List<Attendance>? Attendances { get; set; }
    }
}
