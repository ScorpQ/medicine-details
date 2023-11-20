using Business.Abstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IControlService _controlService;

        public TestController(IControlService controlService)
        {
            _controlService = controlService;
        }


        [HttpGet("GetAllPatient")]
        public IActionResult GetAllPatient()
        {
            var result = _controlService.GetAllPatient();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);

            }
        }

        [HttpGet("GetAllDoctor")]
        public IActionResult GetAllDoctor()
        {
            var result = _controlService.GetAllDoctor();
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
