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
    public class PatientAuthManager : IPatientAuthService
    {
        private IPatientService _patientService;
        private ITokenHelper _tokenHelper;

        public PatientAuthManager(IPatientService patientService, ITokenHelper tokenHelper)
        {
            _patientService = patientService;
            _tokenHelper = tokenHelper;
        }

        
        public IDataResult<Patient> Register(PatientForRegisterDto patientForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var patient = new Patient
            {
                TC = patientForRegisterDto.TC,
                FirstName = patientForRegisterDto.FirstName,
                LastName = patientForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _patientService.Add(patient);
            return new SuccessDataResult<Patient>(patient, Messages.UserAdded);
        }

        public IDataResult<Patient> Login(PatientForLoginDto patientForLoginDto)
        {
            var patientToCheck = _patientService.GetByTC(patientForLoginDto.TC);
            if (patientToCheck == null)
            {
                return new ErrorDataResult<Patient>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(patientForLoginDto.Password, patientToCheck.PasswordHash, patientToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Patient>(Messages.PasswordError);
            }

            return new SuccessDataResult<Patient>(patientToCheck, Messages.SuccessfulLogin);
        }

        public IResult PatientExists(string TC)
        {
            if (_patientService.GetByTC(TC) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Patient patient)
        {
            var claims = _patientService.GetClaims(patient);
            var accessToken = _tokenHelper.CreateToken(patient, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
