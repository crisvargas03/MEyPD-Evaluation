using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.Services;
using AteneaBackend.Businesslayer.ViewModels.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteneaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService= attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _attendanceService.GetAll());
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetStudentId()
        {
            return Ok(await _attendanceService.GetTodayId(DateTime.Now));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AttendanceInputModel attendanceInputModel)
        {
            if (attendanceInputModel != null)
            {
                var todayPresent = await _attendanceService.CheckAttendance(attendanceInputModel.StudentId);
                if (!todayPresent)
                {
                    var registerResult = await _attendanceService.Save(attendanceInputModel);
                    if (registerResult != null)
                        return Ok(registerResult);
                }
                return BadRequest();
            }
            return BadRequest("Error al realizar el registro...");
        }
    }
}
