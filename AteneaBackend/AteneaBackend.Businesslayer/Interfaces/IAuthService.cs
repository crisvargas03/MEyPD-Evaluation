using AteneaBackend.Businesslayer.ViewModels.Teacher;

namespace AteneaBackend.Businesslayer.Interfaces
{
    public interface IAuthService
    {
        Task<TeacherViewModel> LoginWithCreds(TeacherLoginInputModel creds);
        Task<TeacherViewModel> Register(TeacherRegisterInputModel registerModel);
    }
}
