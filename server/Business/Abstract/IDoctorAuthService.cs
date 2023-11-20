using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IDoctorAuthService
    {
        IDataResult<Doctor> Register(DoctorForRegisterDto doctorForRegisterDto, string password);
        IDataResult<Doctor> Login(DoctorForLoginDto doctorForLoginDto);
        IResult DoctorExists(string tc);
        // IDataResult<AccessToken> CreateAccessToken(Doctor doctor);
        //Doctor GetByTC(string TC);

    }
}
