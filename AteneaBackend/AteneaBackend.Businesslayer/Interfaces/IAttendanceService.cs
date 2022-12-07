using AteneaBackend.Businesslayer.ViewModels.Attendance;

namespace AteneaBackend.Businesslayer.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceViewModel>> GetAll();
        Task<List<int>> GetTodayId(DateTime date);
        Task<AttendanceViewModel> Save(AttendanceInputModel inputModel);
    }
}
