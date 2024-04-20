using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuestionAnswerDal : EfEntityRepositoryBase<QuestionAnswer, DBContext>, IQuestionAnswerDal
    {
        public List<QuestionAnswerDto> GetAllAnsweredByDoctor(string TC)
        {
            using (DBContext context = new DBContext())
            {
                var result = from q in context.QuestionAnswers
                             join p in context.Prescriptions on q.PrescriptionId equals p.Id
                             join pa in context.Patients on p.PatientTC equals pa.TC
                             join m in context.Medicines on p.MedicineId equals m.Id
                             where q.Answered == true
                             where q.DoctorTC == TC
                             select new QuestionAnswerDto
                             {
                                 Id = q.Id,
                                 DoctorTC = p.DoctorTC,
                                 PatientTC = p.PatientTC,
                                 Question = q.Question,
                                 Title = q.Title,
                                 Answer = q.Answer,
                                 Answered = q.Answered,
                                 PatientName = pa.FirstName,
                                 PatientSurname = pa.LastName,
                                 MedicineName = m.MedicineName,
                             };
                return result.ToList();
            }
        }

        public List<QuestionAnswerDto> GetAllNotAnsweredByDoctor(string TC)
        {
            using (DBContext context = new DBContext())
            {
                var result = from q in context.QuestionAnswers
                             join p in context.Prescriptions on q.PrescriptionId equals p.Id
                             join pa in context.Patients on p.PatientTC equals pa.TC
                             join m in context.Medicines on p.MedicineId equals m.Id
                             where q.Answered == false
                             where q.DoctorTC == TC
                             select new QuestionAnswerDto
                             {
                                 Id = q.Id,
                                 DoctorTC = p.DoctorTC,
                                 PatientTC = p.PatientTC,
                                 Question = q.Question,
                                 Title = q.Title,
                                 Answer = q.Answer,
                                 Answered = q.Answered,
                                 PatientName = pa.FirstName,
                                 PatientSurname = pa.LastName,
                                 MedicineName = m.MedicineName,
                             };
                return result.ToList();
            }
        }
    }
}
