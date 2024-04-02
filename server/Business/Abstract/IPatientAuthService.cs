using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPatientAuthService
    {
        IDataResult<Patient> Register(PatientForRegisterDto patientForRegisterDto, string password);
        IDataResult<Patient> Login(PatientForLoginDto patientForLoginDto);
        IResult PatientExists(string tc);
        IDataResult<AccessToken> CreateAccessToken(Patient patient);
    }
}
