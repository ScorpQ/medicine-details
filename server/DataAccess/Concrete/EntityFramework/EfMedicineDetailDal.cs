using Core.DataAccess;
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
    public class EfMedicineDetailDal : EfEntityRepositoryBase<MedicineDetail, DBContext>, IMedicineDetailDal
    {
        public List<MedicineDetailsDto> GetAllMedicineDetails()
        {
            using (DBContext context = new DBContext())
            {
                var result = from md in context.MedicineDetails
                             join m in context.Medicines on md.MedicineId equals m.Id
                             select new MedicineDetailsDto
                             {
                                 Id = m.Id,
                                 MedicineId = md.MedicineId,
                                 MedicineName = m.MedicineName,
                                 Info = md.Info,
                                 WebSite = md.WebSite,
                             };
                return result.ToList();
            }
        }

        public List<MedicineDetailsDto> GetMedicineDetails(int id)
        {
            using (DBContext context = new DBContext())
            {
                var result = from md in context.MedicineDetails
                             join m in context.Medicines on md.MedicineId equals m.Id
                             where md.MedicineId==id
                             select new MedicineDetailsDto
                             {
                                 Id = m.Id,
                                 MedicineId = md.MedicineId,
                                 MedicineName = m.MedicineName,
                                 Info = md.Info,
                                 WebSite = md.WebSite,
                             };
                return result.ToList();
            }
        }
    }
}
