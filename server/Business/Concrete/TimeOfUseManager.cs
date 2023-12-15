using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TimeOfUseManager : ITimeOfUseService
    {
        private readonly ITimeOfUseDal _timeOfUseDal;
        public TimeOfUseManager(ITimeOfUseDal timeOfUseDal)
        {
            _timeOfUseDal = timeOfUseDal;
        }
        public IResult Add(TimeOfUse timeOfUse)
        {
            _timeOfUseDal.Add(timeOfUse);
            return new SuccessResult(Messages.TimeOfUseAdded);
        }

        public IDataResult<List<TimeOfUse>> GetAll()
        {
            return new DataResult<List<TimeOfUse>>(_timeOfUseDal.GetAll(), true, Messages.TimeOfUseGetAll);
        }
    }
}
