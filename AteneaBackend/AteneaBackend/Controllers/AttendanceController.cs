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
        public async Task<IActionResult> Save([FromBody] List<AttendanceInputModel> attendanceInputModel)
        {
            foreach (var item in attendanceInputModel)
            {
                if (item != null)
                {
                    var result = await _attendanceService.Save(item);
                    if (result != null)
                    {
                        
                    }
                }
            }
            return Ok();
        }
    }
}
