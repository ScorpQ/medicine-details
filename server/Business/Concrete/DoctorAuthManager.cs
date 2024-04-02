using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class DoctorAuthManager : IDoctorAuthService
    {
        private IDoctorService _doctorService;
        public DoctorAuthManager(IDoctorService doctorService)
        {
            _doctorService = doctorService; 
        }

        public IResult DoctorExists(string TC)
        {
            if (_doctorService.GetByTC(TC) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

 
        public IDataResult<Doctor> Login(DoctorForLoginDto doctorForLoginDto)
        {
            var doctorToCheck = _doctorService.GetByTC(doctorForLoginDto.TC);
            if (doctorToCheck == null)
            {
                return new ErrorDataResult<Doctor>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(doctorForLoginDto.Password, doctorToCheck.PasswordHash, doctorToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Doctor>(Messages.PasswordError);
            }

            return new SuccessDataResult<Doctor>(_doctorService.GetByTC(doctorForLoginDto.TC), Messages.SuccessfulLogin);
        }

        
        public IDataResult<Doctor> Register(DoctorForRegisterDto doctorForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var doctor = new Doctor
            {
                TC = doctorForRegisterDto.TC,
                FirstName = doctorForRegisterDto.FirstName,
                LastName = doctorForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _doctorService.Add(doctor);
            return new SuccessDataResult<Doctor>(doctor, Messages.UserAdded);
        }
    }
}
