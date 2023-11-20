using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PatientManager : IPatientService
    {
        IPatientDal _patientDal;

        public PatientManager(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }

        public List<OperationClaim> GetClaims(Patient patient)
        {
            return _patientDal.GetClaims(patient);
        }

        [ValidationAspect(typeof(PatientValidator))]
        public void Add(Patient patient)
        {
            _patientDal.Add(patient);
        }

        public Patient GetByTC(string TC)
        {
            return _patientDal.Get(p => p.TC == TC);
        }

    }
}
