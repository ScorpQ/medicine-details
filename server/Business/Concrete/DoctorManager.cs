﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DoctorManager :IDoctorService
    {
        private readonly IDoctorDal _doctorDal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorManager(IDoctorDal doctorDal, IHttpContextAccessor httpContextAccessor)
        {
            _doctorDal = doctorDal;
            _httpContextAccessor = httpContextAccessor;
        }


        [ValidationAspect(typeof(DoctorValidator))]
        public void Add(Doctor doctor)
        {
            _doctorDal.Add(doctor);
        }

        public Core.Utilities.Results.IResult Delete(int id)
        {
            var doctor = _doctorDal.Get(p => p.Id == id);
            if (doctor != null)
            {
                _doctorDal.Delete(doctor);
                return new SuccessResult(Messages.DoctorDelete);
            }
            else
            {
                return new ErrorResult(Messages.DoctorNotDelete);
            }
        }

        public IDataResult<List<Doctor>> GetAll()
        {
            return new DataResult<List<Doctor>>(_doctorDal.GetAll(), true, Messages.UserGetAll);
        }

        public Doctor GetByTC(string TC)
        {
            return _doctorDal.Get(d => d.TC == TC);
        }

        public IDataResult<List<DoctorImageDto>> GetDoctorImage(string TC)
        {
            string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var doctor = _doctorDal.GetDoctorImageDto(TC).ToList();

            doctor.ForEach(d =>
            {
                d.ImagePath = $"{baseUrl}/{PathConstants.ImagesDoctorPath}{d.ImagePath}";
            });

            return new DataResult<List<DoctorImageDto>>(doctor, true, Messages.UserGetAll);
        }

        public Core.Utilities.Results.IResult Update(string TC, string oldPassword, string newPassword)
        {
            var result = _doctorDal.Get(p => p.TC == TC);
            if (!HashingHelper.VerifyPasswordHash(oldPassword, result.PasswordHash, result.PasswordSalt))
            {
                return new ErrorDataResult<Patient>(Messages.PasswordError);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
            var doctor = new Doctor
            {
                Id = result.Id,
                TC = result.TC,
                FirstName = result.FirstName,
                LastName = result.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = result.Status,
            };
            _doctorDal.Update(doctor);
            return new SuccessResult(Messages.PasswordUpdated);
        }
    }
}
