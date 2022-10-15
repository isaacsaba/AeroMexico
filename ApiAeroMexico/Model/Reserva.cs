using System.Text.Json.Serialization;

namespace ApiAeroMexico.Model
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        
        public int VuelosId { get; set; }
        public int PasajerosId { get; set; }

        public  virtual Vuelo Vuelo { get; set; }
        public virtual Pasajero Pasajero { get; set; }

    }
}
