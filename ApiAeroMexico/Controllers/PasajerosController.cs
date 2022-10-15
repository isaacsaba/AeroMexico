using ApiAeroMexico.Model;
using ApiAeroMexico.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAeroMexico.Controllers
{
    [Authorize]
    public class PasajerosController : ControllerBase
    {

        IPasajerosServices _pasajerosServices;
        

        public PasajerosController(IPasajerosServices pasajerosServices)
        {
            _pasajerosServices = pasajerosServices;

        }

        [HttpPost]
        [Route("Pasajeros/Registro")]
        public IActionResult RegistroVuelos([FromBody] Pasajero pasajero)
        {
            try
            {

                _pasajerosServices.CreatePasajero(pasajero);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("Pasajeros/")]
        public IActionResult ObtenerVuelos()
        {
            try
            {

               

                return Ok(_pasajerosServices.GetPasajero());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
