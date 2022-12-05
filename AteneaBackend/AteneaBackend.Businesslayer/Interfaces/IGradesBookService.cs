using AteneaBackend.Businesslayer.ViewModels.GradeBooks;

namespace AteneaBackend.Businesslayer.Interfaces
{
    public interface IGradesBookService
    {
        Task<GradesBookViewModels> SaveGrade(GradesBookInputModel inputModel);
    }
}
