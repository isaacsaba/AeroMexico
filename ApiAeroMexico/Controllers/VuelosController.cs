using ApiAeroMexico.Model;
using ApiAeroMexico.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAeroMexico.Controllers
{
    

    [Authorize]
    public class VuelosController : ControllerBase
    {

        IVuelosServices _vuelosServices;
        
        
        public VuelosController(IVuelosServices vuelosServices)
        {
            _vuelosServices = vuelosServices;

        }

        [HttpPost]
        [Route("Vuelos/Registro")]
        public IActionResult RegistroVuelos([FromBody]  Vuelo vuelo)
        {
            try {
                if (vuelo.NoVuelo.Length > 4) {
                    return BadRequest("Numero de vuelo excedio los caracteres permitidos");
                }
                if (vuelo.Origen.Length > 2)
                {
                    return BadRequest("Origen excedio los caracteres permitidos");
                }
                if (vuelo.Destino.Length > 2)
                {
                    return BadRequest("Destino excedio los caracteres permitidos");
                }

                var response =  _vuelosServices.CreateVuelo(vuelo);

                return Ok();


            }
            catch (Exception e){
                return BadRequest(e.Message);

            }

        }

        [HttpGet]
        [Route("Vuelos/")]
        public IActionResult ObtenerVuelos(string fechaInicio, string fechafin)
        {
            try
            {
                DateTime inicio = Convert.ToDateTime(fechaInicio);
                DateTime fin = Convert.ToDateTime(fechafin);

                return Ok(_vuelosServices.GetVuelos(inicio, fin));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
