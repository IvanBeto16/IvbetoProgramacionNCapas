using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/empleado")]
    public class EmpleadoController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.AddEF(empleado);
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
        [HttpDelete]
        public IHttpActionResult Delete(string numeroEmpleado)
        {
            ML.Result result = BL.Empleado.DeleteEF(numeroEmpleado);
            if(result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [Route("{numeroEmpleado}")]
        [HttpPut]
        public IHttpActionResult Update(string numeroEmpleado, [FromBody]ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.UpdateEF(empleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{idEmpresa?}/{nombreEmpleado?}")]
        [HttpGet]
        public IHttpActionResult GetAll(int? idEmpresa, string nombreEmpleado)
        {
            //Validaciones para caso nulo
            if (idEmpresa == null) idEmpresa = 0;
            if (nombreEmpleado == "null" || nombreEmpleado == "NULL") nombreEmpleado = "";

            ML.Empleado empleado = new ML.Empleado();
            empleado.Nombre = nombreEmpleado;
            empleado.Empresa = new ML.Empresa();
            empleado.Empresa.IdEmpresa = idEmpresa;
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
