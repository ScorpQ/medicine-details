using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineDetailsController : ControllerBase
    {
        private readonly IMedicineDetailService _medicineDetailService;
        public MedicineDetailsController(IMedicineDetailService medicineDetailService)
        {
            _medicineDetailService = medicineDetailService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _medicineDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetId")]
        public IActionResult GetId(int id, int pid)
        {
            var result = _medicineDetailService.GetById(id, pid);
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
        public IActionResult Add(MedicineDetail medicineDetail)
        {
            return Ok(_medicineDetailService.Add(medicineDetail));

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_medicineDetailService.Delete(id));
        }

        [HttpPut("Update")]
        public IActionResult Update(MedicineDetail medicineDetail)
        {
            var result = _medicineDetailService.Update(medicineDetail);
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
