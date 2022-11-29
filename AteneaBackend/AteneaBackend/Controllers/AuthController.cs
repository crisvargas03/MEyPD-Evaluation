using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.ViewModels.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AteneaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]TeacherLoginInputModel creds)
        {
            if (creds != null)
            {
                var loginInfo = await _authService.LoginWithCreds(creds);
                if (loginInfo != null)
                    return Ok(new { loginInfo, Msg = "Loging Exitoso"});
            }
            return BadRequest(new { Alerta = "Credenciales incorrectas..." });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]TeacherRegisterInputModel inputModel)
        {
            if (inputModel != null)
            {
                var registerResult = await _authService.Register(inputModel);
                if (registerResult != null)
                    return Ok(registerResult);
            }
            return BadRequest("Error al realizar el registro...");
        }
    }
}
