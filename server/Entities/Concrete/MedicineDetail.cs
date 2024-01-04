using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MedicineDetail :IEntity
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public string Info { get; set; }
        public string WebSite { get; set; }
    }
}
