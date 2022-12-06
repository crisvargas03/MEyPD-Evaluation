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

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AttendanceInputModel attendanceInputModel)
        {
            if (attendanceInputModel != null)
            {
                var result = await _attendanceService.Save(attendanceInputModel);
                if (result != null)
                {
                    return Created(result.Id.ToString(), result);
                }
            }
            return BadRequest("Error al guardar el pase de lista...");
        }
    }
}
