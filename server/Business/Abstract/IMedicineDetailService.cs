using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMedicineDetailService
    {
        IDataResult<List<MedicineDetailsDto>> GetById(int id,int pid);
        IDataResult<List<MedicineDetailsDto>> GetAll();
        IResult Add(MedicineDetail medicineDetail);
        IResult Update(MedicineDetail medicineDetail);
        IResult Delete(int id);
    }
}
