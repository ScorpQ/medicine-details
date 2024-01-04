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
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MedicineDetailManager : IMedicineDetailService
    {
        private readonly IMedicineDetailDal _medicineDetailDal;

        public MedicineDetailManager(IMedicineDetailDal medicineDetailDal)
        {
            _medicineDetailDal = medicineDetailDal;
        }

        public IDataResult<List<MedicineDetailsDto>> GetAll()
        {
            return new DataResult<List<MedicineDetailsDto>>(_medicineDetailDal.GetAllMedicineDetails(), true, Messages.MedicineDetailListed);
        }
        public IDataResult<List<MedicineDetailsDto>> GetById(int id)
        {
            return new DataResult<List<MedicineDetailsDto>>(_medicineDetailDal.GetMedicineDetails(id), true, Messages.MedicineDetailListed);
        }
        public IResult Add(MedicineDetail medicineDetail)
        {
           _medicineDetailDal.Add(medicineDetail);
            return new SuccessResult(Messages.MedicineDetailAdded);
        }
        public IResult Update(MedicineDetail medicineDetail)
        {
            _medicineDetailDal.Update(medicineDetail);
            return new SuccessResult(Messages.MedicineDetailUpdated);
        }
        public IResult Delete(int id)
        {
            var medicineDetail = _medicineDetailDal.Get(m => m.Id == id);
            if (medicineDetail != null)
            {
                _medicineDetailDal.Delete(medicineDetail);
                return new SuccessResult(Messages.MedicineDetailDelete);
            }
            else
            {
                return new ErrorResult(Messages.MedicineDetailNotDelete);
            }
        }
    }
}
