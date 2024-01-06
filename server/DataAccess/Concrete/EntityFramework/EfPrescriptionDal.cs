using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPrescriptionDal : EfEntityRepositoryBase<Prescription, DBContext>, IPrescriptionDal
    {
        public List<PrescriptionDto> GetDoctorDto()
        {
            using (DBContext context = new DBContext())
            {
                var result = from p in context.Prescriptions
                             join d in context.Doctors on p.DoctorTC equals d.TC
                             join patient in context.Patients on p.PatientTC equals patient.TC
                             join m in context.Medicines on p.MedicineId equals m.Id
                             join department in context.Departments on d.DepartmentId equals department.Id
                             join t in context.TimeOfUses on p.TimeOfUse equals t.Id
                             join mt in context.MedicineTypes on m.MedicineType equals mt.Id
                             join img in context.MedicineImages on m.Id equals img.MedicineId
                             select new PrescriptionDto
                             {
                                 Id = p.Id,
                                 MedicineId = p.MedicineId,
                                 DoctorName = d.FirstName,
                                 DoctorLastname = d.LastName,
                                 PatientName = patient.FirstName,
                                 PatientLastname = patient.LastName,
                                 MedicineName = m.MedicineName,
                                 StartDate = p.StartDate,
                                 EndDate = p.EndDate,
                                 TimeOfUse = p.TimeOfUse,
                                 Pieces = p.Pieces,
                                 Info = p.Info,
                                 DoctorTC = p.DoctorTC,
                                 PatientTC = p.PatientTC,
                                 DepartmentName = department.DepartmentName,
                                 TimeOfUseName = t.TimeOfUseName,
                                 ImagePath = img.ImagePath,
                                 MedicineTypeId = mt.Id,
                                 MedicineTypeName  = mt.MedicineTypeName                         
                             };
                return result.ToList();
            }
        }

        public List<PrescriptionDto> GetPatientDto()
        {
            using (DBContext context = new DBContext())
            {
                var result = from p in context.Prescriptions
                             join d in context.Doctors on p.DoctorTC equals d.TC
                             join patient in context.Patients on p.PatientTC equals patient.TC
                             join m in context.Medicines on p.MedicineId equals m.Id
                             join department in context.Departments on d.DepartmentId equals department.Id
                             join t in context.TimeOfUses on p.TimeOfUse equals t.Id
                             join mt in context.MedicineTypes on m.MedicineType equals mt.Id
                             join img in context.MedicineImages on m.Id equals img.MedicineId
                             select new PrescriptionDto
                             {
                                 Id = p.Id,
                                 MedicineId = p.MedicineId,
                                 DoctorName = d.FirstName,
                                 DoctorLastname=d.LastName,
                                 PatientName=patient.FirstName,
                                 PatientLastname=patient.LastName,
                                 MedicineName=m.MedicineName,
                                 StartDate=p.StartDate,
                                 EndDate=p.EndDate,
                                 TimeOfUse=p.TimeOfUse,
                                 Pieces=p.Pieces,
                                 Info=p.Info,
                                 DoctorTC=p.DoctorTC,
                                 PatientTC=p.PatientTC,
                                 DepartmentName=department.DepartmentName,
                                 TimeOfUseName=t.TimeOfUseName,
                                 ImagePath = img.ImagePath,
                                 MedicineTypeId = mt.Id,
                                 MedicineTypeName = mt.MedicineTypeName
                             };
                return result.ToList();
            }
        }
    }
}
