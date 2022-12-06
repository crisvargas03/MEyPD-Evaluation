using AteneaBackend.Businesslayer.ViewModels.Attendance;

namespace AteneaBackend.Businesslayer.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceViewModel>> GetAll();
        Task<AttendanceViewModel> Save(AttendanceInputModel inputModel);
    }
}
