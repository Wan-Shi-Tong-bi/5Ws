using DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class KHContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Measurment> Measurments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MeasureValue> MeasureValues { get; set; }

        public KHContext()
            : base("HospitalEntities") { }
    }
}
