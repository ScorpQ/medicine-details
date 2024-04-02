using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface IMedicineImageService
    {
        IResult Add(IFormFile file, int carId);
        IResult Delete(int id);
        IResult Update(IFormFile file, int id);
        IDataResult<List<MedicineImage>> GetAll();
        IDataResult<List<MedicineImage>> GetId(int id);
        IDataResult<List<MedicineImage>> GetById(int id);
    }
}
