namespace AteneaBackend.Businesslayer.ViewModels.Student
{
    public class StudentViewModel  : BaseViewModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string CardnetNumber { get; set; }
        public string Condition { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int TeacherId { get; set; }
    }
}
