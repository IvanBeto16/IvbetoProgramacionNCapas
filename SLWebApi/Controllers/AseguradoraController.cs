using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
    }
}
