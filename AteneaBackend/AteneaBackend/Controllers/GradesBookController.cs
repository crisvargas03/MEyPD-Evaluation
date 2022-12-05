using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.Services;
using AteneaBackend.Businesslayer.ViewModels.GradeBooks;
using Microsoft.AspNetCore.Mvc;

namespace AteneaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesBookController : ControllerBase
    {
        private readonly IGradesBookService _gradesService;

        public GradesBookController(IGradesBookService gradesService)
        {
            _gradesService = gradesService;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] GradesBookInputModel inputModel)
        {
            if (inputModel != null)
            {
                var result = await _gradesService.SaveGrade(inputModel);
                if (result != null)
                {
                    return Created(result.Id.ToString(), result);
                }
            }
            return BadRequest("Error al crear el libro de calificacion...");
        }
    }
}
