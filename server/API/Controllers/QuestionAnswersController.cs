using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionAnswersController : ControllerBase
    {
        private readonly IQuestionAnswerService _questionAnswerService;
        public QuestionAnswersController(IQuestionAnswerService questionAnswerService)
        {
            _questionAnswerService = questionAnswerService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _questionAnswerService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetAllAnsweredByDoctorTC")]
        public IActionResult GetAllAnsweredByDoctorTC(string doctorTC)
        {
            var result = _questionAnswerService.GetAllAnsweredByDoctorTC(doctorTC);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetAllNotAnsweredByDoctorTC")]
        public IActionResult GetAllNotAnsweredByDoctorTC(string doctorTC)
        {
            var result = _questionAnswerService.GetAllNotAnsweredByDoctorTC(doctorTC);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetAllAnsweredByPatientTC")]
        public IActionResult GetAllAnsweredByPatinetTC(string patientTC)
        {
            var result = _questionAnswerService.GetAllAnsweredByPatientTC(patientTC);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetAllNotAnsweredByPatientTC")]
        public IActionResult GetAllNotAnsweredByPatientTC(string patientTC)
        {
            var result = _questionAnswerService.GetAllNotAnsweredByPatientTC(patientTC);

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
            var result = _questionAnswerService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetByPrescriptionId")]
        public IActionResult GetByPrescriptionId(int id)
        {
            var result = _questionAnswerService.GetByPrescriptionId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetByPrescriptionIdBool")]
        public IActionResult GetByPrescriptionIdBool(int id)
        {
            var result = _questionAnswerService.GetByPrescriptionId(id);

            if (result.Data==null)
            {
                return Ok(false);
            }
            else
            {
                return BadRequest(true);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(QuestionAnswer questionAnswer)
        {
            return Ok(_questionAnswerService.Add(questionAnswer));
        }

        [HttpPut("Update")]
        public IActionResult Update(QuestionAnswer questionAnswer)
        {
            var result = _questionAnswerService.Update(questionAnswer);
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
            var result = _questionAnswerService.Delete(id);
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
