using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppCarrozzeriaAuto.Models;

namespace WebAppCarrozzeriaAuto.Database
{
    public class ConcessionarioContext : IdentityDbContext<IdentityUser>
    {
        DbSet<Tipo> Tipi { get; set; }
        DbSet<Modello> Modelli { get; set; }
        DbSet<Marca> Marche { get; set; }
        DbSet<Auto> Auto { get; set; }
        DbSet<SpecificheTecniche> SpecificheTecniche { get; set; }
        DbSet<AcquisizioneAuto> AcquisizioniAuto { get; set; }
        DbSet<VenditaAutoUtente> VenditeAuto { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Concessionario;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
