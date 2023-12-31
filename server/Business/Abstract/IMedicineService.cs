﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMedicineService
    {
        IDataResult<List<Medicine>> GetAll();
        IDataResult<Medicine> GetById(int id);
        IDataResult<List<MedicineDto>> GetByTC(string TC);
        IResult Add(Medicine medicine);
        IResult Update(Medicine medicine);
        IResult Delete(int id);
    }
}
