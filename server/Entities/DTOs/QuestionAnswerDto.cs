using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuestionAnswerDto : IDto
    {
        public int Id { get; set; }
        public string DoctorTC { get; set; }
        public string PatientTC { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string MedicineName { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Answered { get; set; }
    }
}
