using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DoctorManager :IDoctorService
    {
        IDoctorDal _doctorDal;

        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }


        [ValidationAspect(typeof(DoctorValidator))]
        public void Add(Doctor doctor)
        {
            _doctorDal.Add(doctor);
        }

        public Doctor GetByTC(string TC)
        {
            return _doctorDal.Get(d => d.TC == TC);
        }
    }
}
