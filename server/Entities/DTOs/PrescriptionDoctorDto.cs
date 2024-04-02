using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PrescriptionDoctorDto : IDto
    {
        public int Id { get; set; }
        public string DoctorTC { get; set; }
        public string PatientTC { get; set; }
        public int MedicineId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeOfUse { get; set; }
        public string Pieces { get; set; }
        public string Info { get; set; }
        public string DoctorName { get; set; }
        public string DoctorLastname { get; set; }
        public string PatientName { get; set; }
        public string PatientLastname { get; set; }
        public string MedicineName { get; set; }
        public string DepartmentName { get; set; }
        public string TimeOfUseName { get; set; }
    }
}
