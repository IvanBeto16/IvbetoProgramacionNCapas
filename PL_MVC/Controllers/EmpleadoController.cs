using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();

            empleado.Empresa.IdEmpresa = 0;
            empleado.Nombre = "";

            //Llamada al metodo sin servicios SOAP
            //ML.Result result = BL.Empleado.GetAllEF(empleado);

            //Llamada al metodo son servicios SOAP
            ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
            var result = service.GetAll(empleado);

            ML.Result resultEmpresas = BL.Empresa.GetAll();
            if (result.Correct)
            {
                empleado.Empleados = result.Objects.ToList();
                empleado.Empresa.Empresas = resultEmpresas.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(empleado);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Empleado empleado)
        {
            if(empleado.Nombre == null)
            {
                empleado.Nombre = "";
            }

            //Llamada al metodo sin servicios
            //ML.Result result = BL.Empleado.GetAllEF(empleado);

            //Llamada al metodo con servicios SOAP
            ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
            var result = service.GetAll(empleado);

            ML.Result resultEmpresas = BL.Empresa.GetAll();
            empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            if (result.Correct)
            {
                empleado.Empleados = result.Objects.ToList();
                empleado.Empresa.Empresas = resultEmpresas.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(empleado);
        }

        // GET: Empleado/Form
        [HttpGet]
        public ActionResult Form(string numeroEmpleado)
        { 
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            if (numeroEmpleado == null) //Add
            {
                empleado.Empresa.Empresas = resultEmpresa.Objects;
                empleado.Accion = "Add";

            }
            else   //Update
            {
                //Llamada al metodo sin servicios SOAP
                //ML.Result result = BL.Empleado.GetByIdEF(numeroEmpleado);

                //Llamada al metodo con servicios SOAP
                ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
                var result = service.GetById(numeroEmpleado);
                if (result.Correct)
                {
                    //unboxing
                    empleado = (ML.Empleado)result.Object;
                    empleado.Empresa.Empresas = resultEmpresa.Objects;
                    empleado.Accion = "Update";
                }
            }
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (file.ContentLength > 0)
                {
                    empleado.Foto = ConvertirABase64(file);
                }
                if (empleado.Accion == "Add") //Add
                {
                    //Llamada al metodo sin servicios SOAP
                    //ML.Result result = BL.Empleado.AddEF(empleado);

                    //Llamada al metodo con servicios SOAP
                    ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
                    var result = service.Add(empleado);
                    if (result.Correct)
                    {
                        ViewBag.Message = "Se ha agregado un nuevo empleado exitosamente";
                    }
                    else
                    {
                        ViewBag.Message = result.ErrorMessage;
                    }
                }
                else  //Update
                {
                    //Llamada al metodo sin servicios SOAP
                    //ML.Result result = BL.Empleado.UpdateEF(empleado);

                    //Llamada al metodo con servicios SOAP
                    ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
                    var result = service.Update(empleado);
                    if (result.Correct)
                    {
                        ViewBag.Message = "Se ha actualizado al empleado exitosamente";
                    }
                    else
                    {
                        ViewBag.Message = result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                empleado.Empresa = new ML.Empresa();
                ML.Result resultEmpresa = BL.Empresa.GetAll();
                empleado.Empresa.Empresas = resultEmpresa.Objects;

                return View(empleado);
            }
            
        }

        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }

        public ActionResult Delete(string numeroEmpleado)
        {
            //Llamada al metodo sin servicios SOAP
            //ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

            //Llamada al metodo con servicios SOAP
            ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
            var result = service.Delete(numeroEmpleado);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente al usuario";
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar al usuario" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
        
    }
}
