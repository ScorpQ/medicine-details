using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IDoctorService
    {
        void Add(Doctor doctor);
        Doctor GetByTC(string TC);
        IResult Update(string TC, string oldPassword, string newPassword);
        IResult Delete(int id);
        IDataResult<List<Doctor>> GetAll();
    }
}
