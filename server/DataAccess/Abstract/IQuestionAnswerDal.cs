using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IQuestionAnswerDal : IEntityRepository<QuestionAnswer>
    {
        List<QuestionAnswerDto> GetAllAnsweredByDoctor(string TC);
        List<QuestionAnswerDto> GetAllNotAnsweredByDoctor(string TC);

    }
}
