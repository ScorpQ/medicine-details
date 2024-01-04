using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAllPatient()
        {
            var result = _patientService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);

            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_patientService.Delete(id));
        }

        [HttpPut("Update")]
        public IActionResult Update(string TC,string oldPassword,string newPassword)
        {
            var result = _patientService.Update(TC,oldPassword,newPassword);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

    }
}
