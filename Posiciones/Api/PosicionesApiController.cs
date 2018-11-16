using PosicionesNegocio.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace Posiciones.api
{
    public class PosicionesApiController : ApiController
    {
        [HttpPost]
        public JsonResult<RespuestaBusqueda> BuscarPosicion(ParamBusqueda oParam)
        {

            PosicionesNegocio.PosicionesManager posicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = posicionesManager.TraerPosiciones(oParam);

            return Json(model);

        }

        [HttpGet]
        public JsonResult<List<ListadoPalabras>> TraerPalabras()
        {

            PosicionesNegocio.PosicionesManager posicionesManager = new PosicionesNegocio.PosicionesManager();
            var model = posicionesManager.TraerPalabras();

            return Json(model);

        }
    }
    
}
