using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class DBContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API"));
            configurationManager.AddJsonFile("appsettings.json");
            optionsBuilder.UseSqlServer(configurationManager.GetConnectionString("sqlConnection"));
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineDetail> MedicineDetails { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TimeOfUse> TimeOfUses { get; set; }

    }
}
