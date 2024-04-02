using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineImageController : ControllerBase
    {
        private readonly IMedicineImageService _medicineImageService;

        public MedicineImageController(IMedicineImageService medicineImageService)
        {
            _medicineImageService = medicineImageService;
        }

        [HttpGet("GetAllImage")]
        public IActionResult GetAllImage()
        {
            var result = _medicineImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _medicineImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddImage")]
        public IActionResult AddImage(IFormFile formFile, int id)
        {
            return Ok(_medicineImageService.Add(formFile, id));
        }

        [HttpPut("UpdateImage")]
        public IActionResult UpdateColor(IFormFile file, int id)
        {
            var result = _medicineImageService.Update(file, id);
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
            var result = _medicineImageService.Delete(id);
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
