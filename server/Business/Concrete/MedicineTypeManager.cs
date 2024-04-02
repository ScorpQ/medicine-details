using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MedicineTypeManager : IMedicineTypeService
    {
        private readonly IMedicineTypeDal _medicineTypeDal;

        public MedicineTypeManager(IMedicineTypeDal medicineTypeDal)
        {
            _medicineTypeDal = medicineTypeDal;
        }

        public IResult Add(MedicineType medicineType)
        {
            _medicineTypeDal.Add(medicineType);
            return new SuccessResult(Messages.MedicineTypeAdded);
        }

        public IDataResult<List<MedicineType>> GetAll()
        {
            return new DataResult<List<MedicineType>>(_medicineTypeDal.GetAll(), true, Messages.MedicineTypeGetAll);
        }
    }
}
