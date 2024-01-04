using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDoctorDal : EfEntityRepositoryBase<Doctor, DBContext>, IDoctorDal
    {
        public List<DoctorImageDto> GetDoctorImageDto(string TC)
        {
            using (DBContext context = new DBContext())
            {
                var result = from d in context.Doctors
                             join img in context.DoctorImages on d.Id equals img.DoctorId
                             where d.TC == TC
                             select new DoctorImageDto
                             {
                                 Id = d.Id,
                                 FirstName = d.FirstName,
                                 LastName = d.LastName,
                                 ImageId=img.Id,
                                 ImagePath=img.ImagePath,
                             };
                return result.ToList();
            }
        }

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
