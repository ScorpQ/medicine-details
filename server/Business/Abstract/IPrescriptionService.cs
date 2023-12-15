using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPrescriptionService
    {
        IDataResult<List<Prescription>> GetAll();
        IDataResult<List<Prescription>> GetByTC(string TC);
        IResult Add(Prescription prescription);
        IResult Update(Prescription prescription);
        IResult Delete(int id);
        IDataResult<List<PrescriptionDto>> GetDtoDetails(string TC);
    }
}
