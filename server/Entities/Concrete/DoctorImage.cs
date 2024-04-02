using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DoctorImage :IEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string ImagePath { get; set; }
    }
}
