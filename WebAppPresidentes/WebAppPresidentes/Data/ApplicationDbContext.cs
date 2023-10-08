using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppPresidentes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public class Usuario : IdentityUser
        {
            public String Nombres { get; set; }
            public String APaterno { get; set; }
            public String AMaterno { get; set; }
            public String DNI { get; set; }
            public String Direccion { get; set; }
            public String Password { get; set; }

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuario>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("AspNetUsers");
                entityTypeBuilder.Property(x => x.UserName)
                .HasMaxLength(124)
                .HasDefaultValue(0);
                entityTypeBuilder.Property(u => u.Nombres)
                .HasMaxLength(60);
                entityTypeBuilder.Property(u => u.APaterno)
                .HasMaxLength(60);
                entityTypeBuilder.Property(u => u.AMaterno)
                .HasMaxLength(60);
                entityTypeBuilder.Property(u => u.DNI)
                .HasMaxLength(8);
                entityTypeBuilder.Property(u => u.Direccion)
                .HasMaxLength(124);
                entityTypeBuilder.Property(u => u.Password)
                    .HasMaxLength(124);
            });
        }
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<WebAppPresidentes.Models.Entidades.Presidentes> Presidentes { get; set; }
        public virtual DbSet<WebAppPresidentes.Models.Entidades.Conyuge> Conyuge { get; set; }
        public virtual DbSet<WebAppPresidentes.Models.Entidades.Paises> Paises { get; set; }
        public virtual DbSet<WebAppPresidentes.Models.Entidades.Profesion> Profesiones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-73T2OMK9;Database=Presidentes;" +
                "User id=sa;Password=Calabera12;MultipleActiveResultSets=True");
        }
    }
}