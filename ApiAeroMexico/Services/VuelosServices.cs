using ApiAeroMexico.Context;
using ApiAeroMexico.Model;
using Microsoft.Extensions.Configuration;

namespace ApiAeroMexico.Services
{
    public class VuelosServices : IVuelosServices
    {
        AeroMexicoContext context;


        public VuelosServices(AeroMexicoContext context)
        {
            this.context = context;
        }
        public async Task CreateVuelo(Vuelo vuelo)
        {
            context.Vuelos.Add(vuelo);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Vuelo> GetVuelos(DateTime fechaInicio, DateTime fechafin)
        {
            return context.Vuelos.Where(x => x.FechaSalida <= fechafin && x.FechaSalida >= fechaInicio);
        }
    }
}

public interface IVuelosServices{

    Task CreateVuelo(Vuelo vuelo);

    IEnumerable<Vuelo> GetVuelos(DateTime fechaInicio, DateTime fechafin);
}
