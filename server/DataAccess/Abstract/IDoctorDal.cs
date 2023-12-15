using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IDoctorDal : IEntityRepository<Doctor>
    {
        List<DoctorDto> GetDto(string TC);
    }
}

