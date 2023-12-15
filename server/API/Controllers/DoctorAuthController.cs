using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAuthController : ControllerBase
    {
        private IDoctorAuthService _doctorAuthService;

        public DoctorAuthController(IDoctorAuthService doctorAuthService)
        {
            _doctorAuthService = doctorAuthService;
        }

        [HttpPost("Login")]
        public ActionResult Login(DoctorForLoginDto doctorForLoginDto)
        {
            var doctorToLogin = _doctorAuthService.Login(doctorForLoginDto);
            if (!doctorToLogin.Success)
            {
                return BadRequest(doctorToLogin.Message);
            }

            if (doctorToLogin.Success)
            {
                return Ok(doctorToLogin.Data.TC);
            }

            return BadRequest(doctorToLogin.Message);
        }

        [HttpPost("Register")]
        public ActionResult Register(DoctorForRegisterDto doctorForRegisterDto)
        {
            var doctorExists = _doctorAuthService.DoctorExists(doctorForRegisterDto.TC);
            if (!doctorExists.Success)
            {
                return BadRequest(doctorExists.Message);
            }

            var registerResult = _doctorAuthService.Register(doctorForRegisterDto, doctorForRegisterDto.Password);
            if (registerResult.Success)
            {
                return Ok(registerResult.Data);
            }

            return BadRequest(registerResult.Message);
        }
    }
}
