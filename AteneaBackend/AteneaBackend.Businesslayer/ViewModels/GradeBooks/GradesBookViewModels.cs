using AteneaBackend.Datalayer.Models;

namespace AteneaBackend.Businesslayer.ViewModels.GradeBooks
{
    public class GradesBookViewModels : BaseModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }
    }
}
