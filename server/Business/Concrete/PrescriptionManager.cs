using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
namespace Business.Concrete
{
    public class PrescriptionManager : IPrescriptionService
    {
        private readonly IPrescriptionDal _prescriptionDal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PrescriptionManager(IPrescriptionDal prescriptionDal, IHttpContextAccessor httpContextAccessor)
        {
            _prescriptionDal = prescriptionDal;
            _httpContextAccessor = httpContextAccessor;
        }
        public Core.Utilities.Results.IResult Add(Prescription prescription)
        {
            _prescriptionDal.Add(prescription);
            return new SuccessResult(Messages.PrescriptionAdded);
        }

        public Core.Utilities.Results.IResult Delete(int id)
        {
            var prescription = _prescriptionDal.Get(p => p.Id==id);
            if (prescription != null)
            {
                _prescriptionDal.Delete(prescription);
                return new SuccessResult(Messages.PrescriptionDelete);
            }
            else
            {
                return new ErrorResult(Messages.PrescriptionNotDelete);
            }
        }

        public IDataResult<List<Prescription>> GetAll()
        {
            return new DataResult<List<Prescription>>(_prescriptionDal.GetAll(), true, Messages.PrescriptionListed);
        }

        public IDataResult<List<Prescription>> GetByTC(string TC)
        {
            return new SuccessDataResult<List<Prescription>>(_prescriptionDal.GetAll(p => p.PatientTC.Equals(TC)), Messages.PrescriptionListedByTC);
        }

        public IDataResult<List<PrescriptionDto>> GetDtoPatientDetails(string TC)
        {
            string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var prescriptions = _prescriptionDal.GetPatientDto()
                                .Where(d => d.PatientTC == TC)
                                .ToList();

            prescriptions.ForEach(p =>
            {
                p.ImagePath = $"{baseUrl}/{PathConstants.ImagesMedicinePath}{p.ImagePath}";
            });

            return new DataResult<List<PrescriptionDto>>(prescriptions, true, Messages.PrescriptionDtoListed);
            
        }

        public IDataResult<List<PrescriptionDto>> GetDtoDoctorDetails(string TC)
        {
            
            string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var prescriptions = _prescriptionDal.GetDoctorDto()
                                .Where(d => d.DoctorTC == TC)
                                .ToList();

            prescriptions.ForEach(p =>
            {
                p.ImagePath = $"{baseUrl}/{PathConstants.ImagesMedicinePath}{p.ImagePath}";
            });

            return new DataResult<List<PrescriptionDto>>(prescriptions, true, Messages.PrescriptionDtoListed);
            //return new DataResult<List<PrescriptionDto>>(_prescriptionDal.GetDoctorDto().Where(d=>d.DoctorTC==TC).ToList(), true, Messages.PrescriptionDtoListed);
        }

        public Core.Utilities.Results.IResult Update(Prescription prescription)
        {
            _prescriptionDal.Update(prescription);
            return new SuccessResult(Messages.PrescriptionUpdated);
        }
    }
}
