using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionAnswerManager : IQuestionAnswerService
    {
        private readonly IQuestionAnswerDal _questionAnswerDal;

        public QuestionAnswerManager(IQuestionAnswerDal questionAnswerDal)
        {
            _questionAnswerDal = questionAnswerDal;
        }

        public IResult Add(QuestionAnswer questionAnswer)
        {
            _questionAnswerDal.Add(questionAnswer);
            return new SuccessResult(Messages.QuestionAnswerAdded);
        }

        public IResult Delete(int id)
        {
            var questionAnswer = _questionAnswerDal.Get(d => d.Id == id);
            if (questionAnswer != null)
            {
                _questionAnswerDal.Delete(questionAnswer);
                return new SuccessResult(Messages.QuestionAnswerDelete);
            }
            else
            {
                return new ErrorResult(Messages.QuestionAnswerNotDelete);
            }
        }

        public IDataResult<List<QuestionAnswer>> GetAll()
        {
            return new DataResult<List<QuestionAnswer>>(_questionAnswerDal.GetAll(), true, Messages.QuestionAnswerGetAll);
        }
        public IDataResult<List<QuestionAnswer>> GetAllAnsweredByDoctorTC(string doctorTC)
        {
            return new DataResult<List<QuestionAnswer>>(_questionAnswerDal.GetAll(d => d.DoctorTC == doctorTC && d.Answered == true), true, Messages.QuestionAnswerGetAll);
        }
        public IDataResult<List<QuestionAnswer>> GetAllNotAnsweredByDoctorTC(string doctorTC)
        {
            return new DataResult<List<QuestionAnswer>>(_questionAnswerDal.GetAll(d => d.DoctorTC == doctorTC && d.Answered == false), true, Messages.QuestionAnswerGetAll);
        }

        public IDataResult<List<QuestionAnswer>> GetAllAnsweredByPatientTC(string patientTC)
        {
            return new DataResult<List<QuestionAnswer>>(_questionAnswerDal.GetAll(d => d.PatientTC == patientTC && d.Answered == true), true, Messages.QuestionAnswerGetAll);
        }
        public IDataResult<List<QuestionAnswer>> GetAllNotAnsweredByPatientTC(string patinetTC)
        {
            return new DataResult<List<QuestionAnswer>>(_questionAnswerDal.GetAll(d => d.PatientTC == patinetTC && d.Answered == false), true, Messages.QuestionAnswerGetAll);
        }

        public IDataResult<QuestionAnswer> GetById(int id)
        {
            return new DataResult<QuestionAnswer>(_questionAnswerDal.Get(d => d.Id == id), true, Messages.QuestionAnswerListedById);
        }
        public IResult Update(QuestionAnswer QuestionAnswer)
        {
            _questionAnswerDal.Update(QuestionAnswer);
            return new SuccessResult(Messages.QuestionAnswerUpdated);
        }
    }
}
