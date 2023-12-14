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
    public class PrescriptionManager : IPrescriptionService
    {
        public IResult Add(Prescription prescription)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Prescription>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Prescription> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Prescription>> GetDto()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Prescription prescription)
        {
            throw new NotImplementedException();
        }
    }
}
