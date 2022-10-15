using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiAeroMexico.Model
{
    public class Pasajero
    {
        public int PasajeroId { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

       [JsonIgnore]
        public virtual ICollection<Reserva> Reservas { get; set; }

    }
}
