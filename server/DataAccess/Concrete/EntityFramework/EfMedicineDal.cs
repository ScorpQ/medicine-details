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
    public class EfMedicineDal : EfEntityRepositoryBase<Medicine, DBContext>, IMedicineDal
    {
        public List<MedicineDto> GetDto(string TC)
        {
            using (DBContext context = new DBContext())
            {
                var result = from m in context.Medicines
                             join department in context.Departments on m.DepartmentId equals department.Id
                             join d in context.Doctors on department.Id equals d.DepartmentId                          
                             where d.TC == TC
                             select new MedicineDto
                             {
                                Id= m.Id,
                                MedicineName=m.MedicineName,
                                DepartmentId=m.DepartmentId
                             };
                return result.ToList();
            }
        }

        
    }
}
