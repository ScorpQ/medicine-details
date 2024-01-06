using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MedicineType :IEntity
    {
        public int Id { get; set; }
        public string MedicineTypeName { get; set; }
    }
}
