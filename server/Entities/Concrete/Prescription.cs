using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Prescription : IEntity
    {
        public int Id { get; set; }
        public string DoctorTC {  get; set; }
        public string PatientTC { get; set; }
        public int MedicineId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeOfUse { get; set; }
        public string Pieces { get; set; }
        public string Info { get; set; }
    }
}
