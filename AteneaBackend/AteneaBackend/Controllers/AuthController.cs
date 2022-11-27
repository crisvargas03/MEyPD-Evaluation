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

        [HttpPost]
        public async Task<IActionResult> Login(TeacherLoginInputModel creds)
        {
            if (creds != null)
            {
                var loginInfo = await _authService.LoginWithCreds(creds);
                if (loginInfo != null)
                    return Ok(new { loginInfo, Msg = "Loging Exitoso"});
            }
            return BadRequest(new { Alerta = "Credenciales incorrectas..." });
        }

        [HttpPost]
        public async Task<IActionResult> Register(TeacherRegisterInputModel inputModel)
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
