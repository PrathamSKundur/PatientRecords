using Microsoft.EntityFrameworkCore;
namespace Fresh.Models
{
public class PatientContext :DbContext
    {
        
            public PatientContext(DbContextOptions<PatientContext> options) : base(options)
            {
            }
            public DbSet<Patient> patients { get; set; }
        
    }
}