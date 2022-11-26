﻿using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.ViewModels.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteneaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _studentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var student = await _studentService.GetById(id);
            if (student != null)
                return Ok(student);

            return NotFound("Estudiante no encontrado...");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Insert([FromBody] StudentInputModel inputModel)
        {
            if (inputModel != null)
            {
                var result = await _studentService.Create(inputModel);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest("Error al crear el Estudiante...");
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Modify([FromBody] StudentInputModel inputModel, int id)
        {
            if (inputModel != null && id != 0)
            {
                var result = await _studentService.Update(inputModel, id);
                if (result)
                {
                    return Ok("Estudiante editado con Exito!");
                }
            }
            return BadRequest("Error al modificar el Estudiante...");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.Delete(id);
            if (result)
            {
                return Ok("Estudiante eliminado con Exito!");
            }
            else
            {
                return BadRequest("Error al eliminar el Estudiante...");
            }
        }
    }
}
