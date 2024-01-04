using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPatientService
    {
        List<OperationClaim> GetClaims(Patient patient);
        void Add(Patient patient);
        Patient GetByTC(string TC);
        IResult Update(string TC,string oldPassword,string newPassword);
        IResult Delete(int id);
        IDataResult<List<Patient>> GetAll();
    }
}
