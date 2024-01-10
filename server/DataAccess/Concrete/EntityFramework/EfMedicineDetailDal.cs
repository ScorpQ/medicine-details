using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMedicineDetailDal : EfEntityRepositoryBase<MedicineDetail, DBContext>, IMedicineDetailDal
    {
        public List<MedicineDetailsDto> GetAllMedicineDetails()
        {
            using (DBContext context = new DBContext())
            {
                var result = from md in context.MedicineDetails
                             join m in context.Medicines on md.MedicineId equals m.Id
                             join img in context.MedicineImages on m.Id equals img.MedicineId
                             join mt in context.MedicineTypes on m.MedicineType equals mt.Id
                             select new MedicineDetailsDto
                             {
                                 Id = m.Id,
                                 MedicineId = md.MedicineId,
                                 MedicineName = m.MedicineName,
                                 Info = md.Info,
                                 WebSite = md.WebSite,
                                 ImagePath =img.ImagePath,
                                 MedicineTypeId = mt.Id,
                                 MedicineTypeName = mt.MedicineTypeName,
                             };
                return result.ToList();
            }
        }

        public List<MedicineDetailsDto> GetMedicineDetails(int id,int pid)
        {
            using (DBContext context = new DBContext())
            {
                var result = from md in context.MedicineDetails
                             join m in context.Medicines on md.MedicineId equals m.Id
                             join img in context.MedicineImages on m.Id equals img.MedicineId
                             join mt in context.MedicineTypes on m.MedicineType equals mt.Id
                             join p in context.Prescriptions on pid equals p.Id
                             where md.MedicineId==id
                             select new MedicineDetailsDto
                             {
                                 Id = m.Id,
                                 MedicineId = md.MedicineId,
                                 MedicineName = m.MedicineName,
                                 Info = md.Info,
                                 WebSite = md.WebSite,
                                 ImagePath = img.ImagePath,
                                 MedicineTypeId=mt.Id,
                                 MedicineTypeName=mt.MedicineTypeName,
                                 DoctorPrescriptionInfo=p.Info,  
                             };
                return result.ToList();
            }
        }
    }
}
