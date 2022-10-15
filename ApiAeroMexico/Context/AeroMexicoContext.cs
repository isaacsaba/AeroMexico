using ApiAeroMexico.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading;

namespace ApiAeroMexico.Context
{
    public class AeroMexicoContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        public AeroMexicoContext(DbContextOptions<AeroMexicoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Pasajero>(pasajero =>
            {
                pasajero.ToTable("Pasajero");

                pasajero.HasKey(x => x.PasajeroId);

                pasajero.Property(x => x.Nombre).HasMaxLength(255).IsRequired();

                pasajero.Property(x => x.Apellido).HasMaxLength(255).IsRequired();


            }); 
            
            modelBuilder.Entity<Vuelo>(vuelo =>
            {
                vuelo.ToTable("vuelo");

                vuelo.HasKey(x => x.VueloId);

                vuelo.Property(x => x.Origen).HasMaxLength(2).IsRequired();

                vuelo.Property(x => x.Destino).HasMaxLength(2).IsRequired();

                vuelo.Property(x => x.NoVuelo).HasMaxLength(4).IsRequired();


            }); 
            
            modelBuilder.Entity<Reserva>(reserva =>
            {
                reserva.ToTable("Reserva");

                reserva.HasKey(x => x.ReservaId);

                reserva.HasOne(p => p.Pasajero).WithMany(p => p.Reservas).HasForeignKey(p => p.PasajerosId);

                reserva.HasOne(p => p.Vuelo).WithMany(p => p.Reservas).HasForeignKey(p => p.VuelosId);


            }); 
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("User");

                user.HasKey(x => x.UserId);

                user.Property(x => x.UserName).HasMaxLength(255).IsRequired();

                user.Property(x => x.Password).HasMaxLength(255).IsRequired();
                

            });




        }
    }
}
