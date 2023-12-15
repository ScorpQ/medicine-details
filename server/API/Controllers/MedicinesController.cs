using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _medicineService.GetAll();
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
        public IActionResult GetId(int id)
        {
            var result = _medicineService.GetById(id);
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
        public IActionResult Add(Medicine medicine)
        {
            return Ok(_medicineService.Add(medicine));

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_medicineService.Delete(id));
        }

        [HttpPut("Update")]
        public IActionResult Update(Medicine medicine)
        {
            var result = _medicineService.Update(medicine);
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
