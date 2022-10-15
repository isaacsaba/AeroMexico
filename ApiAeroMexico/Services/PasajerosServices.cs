using ApiAeroMexico.Context;
using ApiAeroMexico.Model;

namespace ApiAeroMexico.Services
{
    public class PasajerosServices : IPasajerosServices
    {

        AeroMexicoContext context;


        public PasajerosServices(AeroMexicoContext context)
        {
            this.context = context;
        }
        public async Task CreatePasajero(Pasajero pasajero)
        {
            context.Pasajeros.Add(pasajero);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Pasajero> GetPasajero()
        {
            return context.Pasajeros;
        }
    }

    public interface IPasajerosServices
    {

        Task CreatePasajero(Pasajero pasajero);

        IEnumerable<Pasajero> GetPasajero();
    }
}
