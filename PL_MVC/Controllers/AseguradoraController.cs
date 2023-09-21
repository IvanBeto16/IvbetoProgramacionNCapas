using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.XPath;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Aseguradora
        [HttpGet]
        public ActionResult GetAllAseguradora()
        {
            //Llamada al metodo sin servicios web
            //ML.Result result = BL.Aseguradora.GetAllEF();

            //Usaremos el Servicio web para llamar al metodo
            ServiceReferenceAseguradora.AseguradoraServiceClient service = new ServiceReferenceAseguradora.AseguradoraServiceClient();
            var result = service.GetAll();
            ML.Aseguradora seguro = new ML.Aseguradora();
            if (result.Correct)
            {
                seguro.Aseguradoras = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(seguro);
        }

        // GET
        [HttpGet]
        public ActionResult FormAseguradora(int? IdAseguradora)
        {
            //Instancias para mostrar los datos de la aseguradora y usuarios enlazados
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();
            aseguradora.Usuario.Nombre = "";
            aseguradora.Usuario.ApellidoPaterno = "";

            ML.Result resultUsuarios = BL.Usuario.GetAllEF(aseguradora.Usuario);
            if(IdAseguradora == null) //Add
            {
                aseguradora.Usuario.Usuarios = resultUsuarios.Objects;
            }
            else  //Update
            {
                ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora.Value);
                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    aseguradora.Usuario.Usuarios = resultUsuarios.Objects;
                }
            }

            return View(aseguradora);
        }

        // POST
        [HttpPost]
        public ActionResult FormAseguradora(ML.Aseguradora aseguradora)
        {
            if(aseguradora.IdAseguradora == 0) //Add
            {
                //LLamada al metodo de Add sin servicios web
                //ML.Result result = BL.Aseguradora.AddEF(aseguradora);

                //Llamada al metodo de Add con servicios web
                ServiceReferenceAseguradora.AseguradoraServiceClient service = new ServiceReferenceAseguradora.AseguradoraServiceClient();
                var result = service.Add(aseguradora);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha agregado correctamente la entidad";
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error en la insercion" + result.ErrorMessage;
                }
            }
            else   //Update
            {
                //Llamada al metodo de Update sin servicios web
                //ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);

                //Llamada al metodo de Update con servicios web
                ServiceReferenceAseguradora.AseguradoraServiceClient service = new ServiceReferenceAseguradora.AseguradoraServiceClient();
                var result = service.Update(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha actualizado correctamente la entidad";
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error en la actualizacion" + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        // GET: Aseguradora/Delete/5
        public ActionResult Delete(int IdAseguradora)
        {
            //Llamada al metodo de Delete sin servicios web
            //ML.Result result = BL.Aseguradora.DeleteEF(IdAseguradora);

            //Llamada al metodo de Delete con servicios web
            ServiceReferenceAseguradora.AseguradoraServiceClient service = new ServiceReferenceAseguradora.AseguradoraServiceClient();
            var result = service.Delete(IdAseguradora);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el Seguro exitosamente";
            }
            else
            {
                ViewBag.Message = "Ha ocurrido un error, no se ha podido eliminar el seguro" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

        
    }
}
