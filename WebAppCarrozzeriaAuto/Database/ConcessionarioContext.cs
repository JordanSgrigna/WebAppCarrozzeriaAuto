using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebAppCarrozzeriaAuto.Models;

namespace WebAppCarrozzeriaAuto.Database
{
    public class ConcessionarioContext : IdentityDbContext<IdentityUser>
    {   
        public DbSet<Auto> Auto { get; set; }
        public DbSet<SpecificheTecniche> SpecificheTecniche { get; set; }
        public DbSet<AcquistoAuto> AcquisizioniAuto { get; set; }
        public DbSet<VenditaAutoUtente> VenditeAuto { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DBAutoConcessionario2;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
