using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PatientManager : IPatientService
    {
        IPatientDal _patientDal;

        public PatientManager(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }

        public List<OperationClaim> GetClaims(Patient patient)
        {
            return _patientDal.GetClaims(patient);
        }

        [ValidationAspect(typeof(PatientValidator))]
        public void Add(Patient patient)
        {
            _patientDal.Add(patient);
        }

        public Patient GetByTC(string TC)
        {
            return _patientDal.Get(p => p.TC == TC);
        }

        public IResult Update(string TC,string oldPassword,string newPassword)
        {
            var result = _patientDal.Get(p=>p.TC==TC);
            if (!HashingHelper.VerifyPasswordHash(oldPassword, result.PasswordHash, result.PasswordSalt))
            {
                return new ErrorDataResult<Patient>(Messages.PasswordError);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
            var patient = new Patient
            {
                Id =result.Id,
                TC = result.TC,
                FirstName = result.FirstName,
                LastName = result.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = result.Status,
            };
            _patientDal.Update(patient);
            return new SuccessResult(Messages.PasswordUpdated);
        }

        public IResult Delete(int id)
        {
            var patient = _patientDal.Get(p => p.Id == id);
            if (patient != null)
            {
                _patientDal.Delete(patient);
                return new SuccessResult(Messages.PatientDelete);
            }
            else
            {
                return new ErrorResult(Messages.PatientNotDelete);
            }
        }

        public IDataResult<List<Patient>> GetAll()
        {
            return new DataResult<List<Patient>>(_patientDal.GetAll(), true, Messages.UserGetAll);
        }
    }
}
