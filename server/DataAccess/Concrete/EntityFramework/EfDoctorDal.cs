using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDoctorDal : EfEntityRepositoryBase<Doctor, DBContext>, IDoctorDal
    {
        public List<DoctorDto> GetDto(string TC)
        {
            using (DBContext context = new DBContext())
            {
                var result = from d in context.Doctors
                             join department in context.Departments on d.DepartmentId equals department.Id
                             select new DoctorDto
                             {
                                FirstName = d.FirstName,
                                LastName = d.LastName,
                                DepartmentId = department.Id,
                                DepartmentName=department.DepartmentName,
                                TC = d.TC
                             };
                return result.ToList();
            }
        }
    }
}
