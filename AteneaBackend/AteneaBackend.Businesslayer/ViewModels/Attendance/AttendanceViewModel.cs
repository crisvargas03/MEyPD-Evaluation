namespace AteneaBackend.Businesslayer.ViewModels.Attendance
{
    public class AttendanceViewModel : BaseViewModel
    {
        public int StudentId { get; set; }
        public bool IsPresent { get; set; }
        public string Justification { get; set; }
    }
}
