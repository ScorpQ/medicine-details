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
                             join d in context.Doctors on p.DoctorTC equals d.TC
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
                                 DoctorName = d.FirstName,
                                 DoctorSurname = d.LastName,
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
                             join d in context.Doctors on p.DoctorTC equals d.TC
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
                                 DoctorName = d.FirstName,
                                 DoctorSurname = d.LastName,
                                 MedicineName = m.MedicineName,
                             };
                return result.ToList();
            }
        }
        public List<QuestionAnswerDto> GetAllAnsweredByPatient(string TC)
        {
            using (DBContext context = new DBContext())
            {
                var result = from q in context.QuestionAnswers
                             join p in context.Prescriptions on q.PrescriptionId equals p.Id
                             join pa in context.Patients on p.PatientTC equals pa.TC
                             join m in context.Medicines on p.MedicineId equals m.Id
                             join d in context.Doctors on  q.DoctorTC equals d.TC
                             where q.Answered == true
                             where q.PatientTC == TC
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
                                 DoctorName = d.FirstName,
                                 DoctorSurname = d.LastName,
                                 MedicineName = m.MedicineName,
                             };
                return result.ToList();
            }
        }


        public List<QuestionAnswerDto> GetAllNotAnsweredByPatient(string TC)
        {
            using (DBContext context = new DBContext())
            {
                var result = from q in context.QuestionAnswers
                             join p in context.Prescriptions on q.PrescriptionId equals p.Id
                             join pa in context.Patients on p.PatientTC equals pa.TC
                             join d in context.Doctors on q.DoctorTC equals d.TC
                             join m in context.Medicines on p.MedicineId equals m.Id
                             where q.Answered == false
                             where q.PatientTC == TC
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
                                 DoctorName = d.FirstName,
                                 DoctorSurname = d.LastName,
                                 MedicineName = m.MedicineName,
                             };
                return result.ToList();
            }
        }
    }
}
