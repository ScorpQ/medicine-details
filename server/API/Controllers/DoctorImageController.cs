using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorImageController : ControllerBase
    {
        private readonly IDoctorImageService _doctorImageService;

        public DoctorImageController(IDoctorImageService doctorImageService)
        {
            _doctorImageService = doctorImageService;
        }

        [HttpGet("GetAllImage")]
        public IActionResult GetAllImage()
        {
            var result = _doctorImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByDoctorId")]
        public IActionResult GetByDoctorId(int id)
        {
            var result = _doctorImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("AddImage")]
        public IActionResult AddImage(IFormFile formFile, int id)
        {
            return Ok(_doctorImageService.Add(formFile, id));
        }

        [HttpPut("UpdateImage")]
        public IActionResult UpdateColor(IFormFile file, int id)
        {
            var result = _doctorImageService.Update(file, id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeleteImage")]
        public IActionResult DeleteImage(int id)
        {
            var result = _doctorImageService.Delete(id);
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
