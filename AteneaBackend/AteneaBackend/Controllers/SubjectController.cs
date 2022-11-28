using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteneaBackend.Controllers
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _subjectService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var subject = await _subjectService.GetbById(id);
            if (subject != null)
                return Ok(subject);

            return NotFound("Asignatura no encontrada...");
        }
    }
}
