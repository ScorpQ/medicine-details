using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IDoctorService
    {
        
        void Add(Doctor doctor);
        Doctor GetByTC(string TC);
    }
}
