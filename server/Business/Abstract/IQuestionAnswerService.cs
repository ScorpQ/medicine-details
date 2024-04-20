using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IQuestionAnswerService
    {
        IDataResult<List<QuestionAnswer>> GetAll();
        IDataResult<List<QuestionAnswerDto>> GetAllAnsweredByDoctorTC(string doctorTC);
        IDataResult<List<QuestionAnswerDto>> GetAllNotAnsweredByDoctorTC(string doctorTC);
        IDataResult<List<QuestionAnswerDto>> GetAllAnsweredByPatientTC(string patientTC);
        IDataResult<List<QuestionAnswerDto>> GetAllNotAnsweredByPatientTC(string patientTC);
        IDataResult <QuestionAnswer> GetByPrescriptionId(int id);

        IDataResult<QuestionAnswer> GetById(int Id);
        IResult Add(QuestionAnswer questionAnswer);
        IResult Update(QuestionAnswer questionAnswer);
        IResult Delete(int id);
    }
}
