using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;

namespace ApiAeroMexico.Model
{
    public class Vuelo
    {
        public int VueloId { get; set; }

        public string NoVuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reserva> Reservas { get; set; }

    }
}
