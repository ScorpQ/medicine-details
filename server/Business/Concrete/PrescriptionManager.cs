using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PrescriptionManager : IPrescriptionService
    {
        private readonly IPrescriptionDal _prescriptionDal;
        public PrescriptionManager(IPrescriptionDal prescriptionDal) 
        { 
            _prescriptionDal = prescriptionDal;
        }
        public IResult Add(Prescription prescription)
        {
            _prescriptionDal.Add(prescription);
            return new SuccessResult(Messages.PrescriptionAdded);
        }

        public IResult Delete(int id)
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

        public IDataResult<List<PrescriptionDto>> GetDtoDetails(string TC)
        {
            return new  DataResult<List<PrescriptionDto>>(_prescriptionDal.GetDto(TC),true ,Messages.PrescriptionDtoListed);
        }

        public IResult Update(Prescription prescription)
        {
            _prescriptionDal.Update(prescription);
            return new SuccessResult(Messages.PrescriptionUpdated);
        }
    }
}
