using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMedicineDetailDal : IEntityRepository<MedicineDetail>
    {
        List<MedicineDetailsDto> GetMedicineDetails(int id,int pid);
        List<MedicineDetailsDto> GetAllMedicineDetails();
    }
}
