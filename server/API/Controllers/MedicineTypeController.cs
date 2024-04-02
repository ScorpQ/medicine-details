using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineTypeController : ControllerBase
    {
        private readonly IMedicineTypeService _medicineTypeService;

        public MedicineTypeController(IMedicineTypeService medicineTypeService)
        {
            _medicineTypeService = medicineTypeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _medicineTypeService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(MedicineType medicineType)
        {
            return Ok(_medicineTypeService.Add(medicineType));
        }
    }
}
