namespace AteneaBackend.Businesslayer.ViewModels.Attendance
{
    public class AttendanceInputModel
    {
        public int StudentId { get; set; }
        public bool IsPresent { get; set; }
        public string Justification { get; set; }
    }
}
