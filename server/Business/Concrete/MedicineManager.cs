using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MedicineManager : IMedicineService
    {
        public IResult Add(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Medicine>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Medicine> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Medicine medicine)
        {
            throw new NotImplementedException();
        }
    }
}
