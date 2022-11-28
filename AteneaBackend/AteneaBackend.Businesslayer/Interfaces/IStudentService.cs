using AteneaBackend.Businesslayer.ViewModels.Student;

namespace AteneaBackend.Businesslayer.Interfaces
{
    public interface IStudentService
    {
        Task<StudentViewModel> Create(StudentInputModel inputModel);
        Task<bool> Delete(int id);
        Task<IEnumerable<StudentViewModel>> GetAll();
        Task<StudentViewModel> GetById(int code);
        Task<StudentViewModel> Update(StudentInputModel inputModel, int id);
    }
}
