using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserControlService _userControlService;

        public UserController(IUserControlService userControlService)
        {
            _userControlService = userControlService;
        }


        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var result = _userControlService.GetAll();
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
