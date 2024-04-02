using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MedicineImage : IEntity
    {
        public int Id { get; set; } 
        public int MedicineId {  get; set; }
        public string ImagePath { get; set; }

    }
}
