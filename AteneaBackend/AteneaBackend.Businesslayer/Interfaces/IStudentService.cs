using AteneaBackend.Businesslayer.ViewModels.Student;

namespace AteneaBackend.Businesslayer.Interfaces
{
    public interface IStudentService
    {
        Task<bool> Create(StudentInputModel inputModel);
        Task<bool> Delete(int id);
        Task<IEnumerable<StudentViewModel>> GetAll();
        Task<StudentViewModel> GetById(int code);
        Task<bool> Update(StudentInputModel inputModel, int id);
    }
}
