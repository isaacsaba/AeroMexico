using ApiAeroMexico.Model;
using ApiAeroMexico.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAeroMexico.Controllers
{

    [Authorize]

    public class ReservasController : ControllerBase
    {

        IReservasServices _reservasServices;


        public ReservasController(IReservasServices reservasServices)
        {
            _reservasServices = reservasServices;

        }

        [HttpPost]
        [Route("Reservas/Registro")]
        public IActionResult RegistroVuelos([FromBody] List<Reserva> reserva)
        {
            try
            {

                _reservasServices.CreateReserva(reserva);


                return Ok();


            }
            catch (Exception e)
            {
                return StatusCode(500);

            }

        }

        [HttpGet]
        [Route("Reservas/")]
        public IActionResult ObtenerVuelos()
        {
            try
            {

                return Ok(_reservasServices.GetReservas());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
