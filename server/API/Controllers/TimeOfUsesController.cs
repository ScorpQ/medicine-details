using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeOfUsesController : ControllerBase
    {
        private readonly ITimeOfUseService _timeOfUseService;
        public TimeOfUsesController(ITimeOfUseService timeOfUseService)
        {
           _timeOfUseService = timeOfUseService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _timeOfUseService.GetAll();

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
        public IActionResult Add(TimeOfUse timeOfUse)
        {
            return Ok(_timeOfUseService.Add(timeOfUse));
        }
    }
}
