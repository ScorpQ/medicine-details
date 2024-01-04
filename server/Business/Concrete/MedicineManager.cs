using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
    public class MedicineManager : IMedicineService
    {
        private readonly IMedicineDal _medicineDal;

        public MedicineManager(IMedicineDal medicineDal) 
        {
            _medicineDal = medicineDal;
        }

          
        public IResult Add(Medicine medicine)
        {
            _medicineDal.Add(medicine);
            return new SuccessResult(Messages.MedicineAdded);
        }

        public IResult Delete(int id)
        {
            var medicine = _medicineDal.Get(m => m.Id==id);
            if(medicine!=null)
            {
                _medicineDal.Delete(medicine);
                return new SuccessResult(Messages.MedicineDelete);
            }
            else
            {
                return new ErrorResult(Messages.PatientNotDelete);
            }
        }

        public IDataResult<List<Medicine>> GetAll()
        {
            return new DataResult<List<Medicine>>(_medicineDal.GetAll(), true, Messages.MedicineDetailListed);
        }

        public IDataResult<Medicine> GetById(int id)
        {
            return new DataResult<Medicine>(_medicineDal.Get(m => m.Id == id), true, Messages.MedicineListedById);
        }

        public IDataResult<List<MedicineDto>> GetByTC(string TC)
        {
            return new DataResult<List<MedicineDto>>(_medicineDal.GetDto(TC), true, Messages.MedicineDetailListed);
        }

        public IResult Update(Medicine medicine)
        {
            _medicineDal.Update(medicine);
            return new SuccessResult(Messages.PasswordUpdated);
        }
    }
}
