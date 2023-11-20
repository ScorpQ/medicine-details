using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ControlManager :IControlService
    {
        IPatientDal _patientDal;
        IDoctorDal _doctorDal;

        public ControlManager(IPatientDal patientDal, IDoctorDal doctorDal)
        {
            _patientDal = patientDal;
            _doctorDal = doctorDal;
        }


        public IDataResult<List<Doctor>> GetAllDoctor()
        {
            return new DataResult<List<Doctor>>(_doctorDal.GetAll(), true, Messages.UserGetAll);
        }

        public IDataResult<List<Patient>> GetAllPatient()
        {
            return new DataResult<List<Patient>>(_patientDal.GetAll(), true, Messages.UserGetAll);
        }
    }
}
