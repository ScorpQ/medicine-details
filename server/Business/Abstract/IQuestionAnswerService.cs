using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IQuestionAnswerService
    {
        IDataResult<List<QuestionAnswer>> GetAll();
        IDataResult<List<QuestionAnswer>> GetAllAnsweredByDoctorTC(string doctorTC);
        IDataResult<List<QuestionAnswer>> GetAllNotAnsweredByDoctorTC(string doctorTC);
        IDataResult<List<QuestionAnswer>> GetAllAnsweredByPatientTC(string patientTC);
        IDataResult<List<QuestionAnswer>> GetAllNotAnsweredByPatientTC(string patientTC);
        IDataResult <QuestionAnswer> GetByPrescriptionId(int id);

        IDataResult<QuestionAnswer> GetById(int Id);
        IResult Add(QuestionAnswer questionAnswer);
        IResult Update(QuestionAnswer questionAnswer);
        IResult Delete(int id);
    }
}
