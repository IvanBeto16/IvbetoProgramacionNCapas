using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/Empleado")]
    public class EmpleadoController : ApiController
    {

        [Route("{idEmpresa}/{nombreEmpleado}")]
        [Route("{idEmpresa?}/{nombreEmpleado?}")]
        [HttpGet]
        public IHttpActionResult GetAll(int? idEmpresa, string nombreEmpleado)
        {
            if (idEmpresa == 0 || idEmpresa == null) idEmpresa = 0;
            if(nombreEmpleado == "null" || nombreEmpleado == null || nombreEmpleado == "") nombreEmpleado = "";
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            empleado.Empresa.IdEmpresa = idEmpresa;
            empleado.Nombre = nombreEmpleado;

            ML.Result result = BL.Empleado.GetAllEF(empleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{numeroEmpleado}")]
        [HttpGet]
        public IHttpActionResult GetById(string numeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = numeroEmpleado;
            ML.Result result = BL.Empleado.GetByIdEF(empleado.NumeroEmpleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
