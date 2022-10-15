using ApiAeroMexico.Context;
using ApiAeroMexico.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiAeroMexico.Services
{
    public class ReservasServices : IReservasServices
    {
        AeroMexicoContext context;


        public ReservasServices(AeroMexicoContext context)
        {
            this.context = context;
        }
        public string CreateReserva(List<Reserva> reserva)
        {
            foreach (var item in reserva)
            {
                context.Reservas.Add(item);

            }
            
            context.SaveChanges();
            return "TRUE";
        }

        public IEnumerable<Reserva> GetReservas()
        {
            return context.Reservas.Include(x => x.Pasajero).Include(x => x.Vuelo);
        }
    }

    public interface IReservasServices
    {

        string CreateReserva(List<Reserva> reserva);

        IEnumerable<Reserva> GetReservas();
    }
}
