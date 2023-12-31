﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MedicineDto : IDto
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public int MedicineTypeId { get; set; }
        public int DepartmentId { get; set; }
    }
}
