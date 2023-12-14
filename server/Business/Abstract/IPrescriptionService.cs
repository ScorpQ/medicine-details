using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<Prescription> GetById(int id);
        IResult Add(Prescription prescription);
        IResult Update(Prescription prescription);
        IResult Delete(int id);
        IDataResult<List<Prescription>> GetDto();
    }
}
