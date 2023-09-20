using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        [HttpGet]
        public ActionResult Cargar()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            return View(result);
        }

        // POST: CargaMasiva Ezxcel
        [HttpPost]
        public ActionResult Cargar(ML.Result result)
        {
            HttpPostedFileBase file = Request.Files["Excel"];

            if (Session["pathExcel"] == null)
            {
                if (file != null)
                {
                    string extensionArchivo = Path.GetExtension(file.FileName);
                    string extensionValida = ConfigurationManager.AppSettings["TipoExcel"];

                    if (extensionArchivo == extensionValida)
                    {
                        //Formato de nombrado de la copia del archivo subido
                        string filePath = Server.MapPath("~/CargaMasiva/") + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                        if (!System.IO.File.Exists(filePath))
                        {
                            file.SaveAs(filePath);
                            //Se obtiene la coneccion con Oledb para leer el excel y se le junta la ruta de la carpeta de las copias
                            string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filePath;
                            ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);
                            if (resultUsuarios.Correct)
                            {
                                ML.Result resultValidacion = BL.Usuario.ValidarExcel(resultUsuarios.Objects);
                                if (resultValidacion.Objects.Count == 0)
                                {
                                    resultValidacion.Correct = true;
                                    Session["pathExcel"] = filePath;
                                }
                                return View(resultValidacion);
                            }
                            else
                            {
                                ViewBag.Message = "El excel no contiene registros";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "El archivo no es del formato excel permitido (.xlsx). Verificar el tipo de archivo.";
                    }
                }
                else
                {
                    ViewBag.Message = "El archivo excel no existe, no ha sido seleccionado. Por favor Seleccione un archivo";
                }
                return View(result);
            }
            else
            {
                string sessionpath = Session["pathExcel"].ToString();
                if(sessionpath != null)
                {
                    //Se obtiene la coneccion con Oledb para leer el excel y se le junta la ruta de la carpeta de las copias
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + sessionpath;
                    ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);
                    if (resultUsuarios.Correct)
                    {
                        ML.Result resultErrores = new ML.Result();
                        resultErrores.Objects = new List<object>();
                        foreach(ML.Usuario usuario in resultUsuarios.Objects)
                        {
                            ML.Result result1 = BL.Usuario.AddEF(usuario);
                            if (!result1.Correct)
                            {
                                //Sacar errores en un TXT
                                string errores = "Ha ocurrido un error con el usuario " + usuario.UserName + " con nombre: " 
                                    + usuario.Nombre + usuario.ApellidoPaterno + usuario.ApellidoMaterno+ 
                                    " donde el error es: " + result1.ErrorMessage;
                                resultErrores.Objects.Add(errores);
                            }
                            Session["pathExcel"] = null;
                        }
                        if(resultErrores.Objects.Count > 0)
                        {
                            string logerrores = Server.MapPath(@"~\Files\logErrores")+'-' 
                                + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                            using(StreamWriter writter = new StreamWriter(logerrores))
                            {
                                foreach(string log in resultErrores.Objects)
                                {
                                    writter.WriteLine(log);
                                }
                            }
                        }
                    }
                }
                else
                {

                }
            }
            return View(result); 
        }

        // GET: CargaMasiva/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargaMasiva/Create
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

        // GET: CargaMasiva/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CargaMasiva/Edit/5
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

        // GET: CargaMasiva/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CargaMasiva/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
