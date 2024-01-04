using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAllPatient()
        {
            var result = _doctorService.GetAll();
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
            return Ok(_doctorService.Delete(id));
        }

        [HttpPut("Update")]
        public IActionResult Update(string TC, string oldPassword, string newPassword)
        {
            var result = _doctorService.Update(TC, oldPassword, newPassword);
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
