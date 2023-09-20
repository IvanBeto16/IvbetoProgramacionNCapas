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
            ML.Result result = BL.Aseguradora.GetAllEF();
            ML.Aseguradora seguro = new ML.Aseguradora();
            if (result.Correct)
            {
                seguro.Aseguradoras = result.Objects;
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
                ML.Result result = BL.Aseguradora.AddEF(aseguradora);
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
                ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
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

        // POST: Aseguradora/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aseguradora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aseguradora/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aseguradora/Delete/5
        public ActionResult Delete(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.DeleteEF(IdAseguradora);
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
