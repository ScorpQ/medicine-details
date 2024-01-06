using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _prescriptionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetByTC")]
        public IActionResult GetTC(string TC)
        {
            var result =_prescriptionService.GetByTC(TC);
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
        public IActionResult Add(Prescription prescription)
        {
            return Ok(_prescriptionService.Add(prescription));

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_prescriptionService.Delete(id));
        }

        [HttpPut("Update")]
        public IActionResult Update(Prescription prescription)
        {
            var result = _prescriptionService.Update(prescription);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetPatientDto")]
        public IActionResult GetPatientDto(string TC)
        {

            return Ok(_prescriptionService.GetDtoPatientDetails(TC));

        }


        [HttpGet("GetDoctorDto")]
        public IActionResult GetDoctorDto(string TC)
        {   
            return Ok(_prescriptionService.GetDtoDoctorDetails(TC));

        }
    }
}
