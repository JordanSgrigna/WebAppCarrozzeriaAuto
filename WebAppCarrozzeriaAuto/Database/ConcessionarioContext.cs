using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebAppCarrozzeriaAuto.Models;

namespace WebAppCarrozzeriaAuto.Database
{
    public class ConcessionarioContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Tipo> Tipi { get; set; }
        public DbSet<Modello> Modelli { get; set; }
        public DbSet<Marca> Marche { get; set; }
        public DbSet<Auto> Auto { get; set; }
        public DbSet<SpecificheTecniche> SpecificheTecniche { get; set; }
        public DbSet<AcquistoAuto> AcquisizioniAuto { get; set; }
        public DbSet<VenditaAutoUtente> VenditeAuto { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DBAutoConcessionario;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
