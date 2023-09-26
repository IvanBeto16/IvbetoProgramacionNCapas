using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/aseguradora")]
    public class AseguradoraController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.AddEF(aseguradora);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("/{idAseguradora}")]
        [HttpPut]
        public IHttpActionResult Update(int idAseguradora, [FromBody]ML.Aseguradora Aseguradora)
        {
            ML.Result result = BL.Aseguradora.UpdateEF(Aseguradora);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("/{idAseguradora}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.DeleteEF(idAseguradora);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            ML.Result result = BL.Aseguradora.GetAllEF();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{idAseguradora}")]
        [HttpGet]
        public IHttpActionResult GetById(int idAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.IdAseguradora = idAseguradora;
            ML.Result result = BL.Aseguradora.GetByIdEF(aseguradora.IdAseguradora);
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
