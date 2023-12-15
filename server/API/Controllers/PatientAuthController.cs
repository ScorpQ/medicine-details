using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAuthController : Controller
    {
        private IPatientAuthService _patientAuthService;

        public PatientAuthController(IPatientAuthService patientAuthService)
        {
            _patientAuthService = patientAuthService;
        }

        [HttpPost("Login")]
        public ActionResult Login(PatientForLoginDto patientForLoginDto)
        {
            var patientToLogin = _patientAuthService.Login(patientForLoginDto);
            if (!patientToLogin.Success)
            {
                return BadRequest(patientToLogin.Message);
            }

            //var result = _patientAuthService.CreateAccessToken(patientToLogin.Data);
            if (patientToLogin.Success)
            {
                return Ok(patientToLogin.Data.TC);
            }

            return BadRequest(patientToLogin.Message);
        }

        [HttpPost("Register")]
        public ActionResult Register(PatientForRegisterDto patientForRegisterDto)
        {
            var patientExists = _patientAuthService.PatientExists(patientForRegisterDto.TC);
            if (!patientExists.Success)
            {
                return BadRequest(patientExists.Message);
            }

            var registerResult = _patientAuthService.Register(patientForRegisterDto, patientForRegisterDto.Password);
            var result = _patientAuthService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
