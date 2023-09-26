using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Configuration;
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
            //ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
            //var result = service.GetAll(empleado);

            //Usando los servicios Web REST
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var responseTask = client.GetAsync(client.BaseAddress + "empleado?idEmpresa=&nombreEmpleado=");
                responseTask.Wait();
                ML.Result resultEmpresas = BL.Empresa.GetAll();
                var resultService = responseTask.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    var readTask = resultService.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    foreach (var employee in readTask.Result.Objects)
                    {
                        ML.Empleado resultEmp = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(employee.ToString());
                        empleado.Empleados.Add(resultEmp);

                    }
                }
                if (resultEmpresas.Correct)
                {
                    empleado.Empresa.Empresas = resultEmpresas.Objects;
                }
                else
                {
                    ViewBag.Message = resultEmpresas.ErrorMessage;
                }
            }
            return View(empleado);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Empleado empleado)
        {
            if (empleado.Nombre == null)
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
                    //ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
                    //var result = service.Add(empleado);

                    //LLamando a los servicios REST
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                        var postTask = client.PostAsJsonAsync<ML.Empleado>(client.BaseAddress + "empleado/", empleado);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Se ha agregado un nuevo empleado exitosamente";
                        }
                        else
                        {
                            ViewBag.Message = "Se ha provocado un error en la insercion";
                        }

                    }
                }
                else  //Update
                {
                    //Llamada al metodo sin servicios SOAP
                    //ML.Result result = BL.Empleado.UpdateEF(empleado);

                    //Llamada al metodo con servicios SOAP
                    //ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
                    //var result = service.Update(empleado);

                    //Llamando a los servicios REST
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                        var putTask = client.PutAsJsonAsync<ML.Empleado>(client.BaseAddress + "empleado/", empleado);
                        putTask.Wait();

                        var result = putTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Se ha actualizado al empleado exitosamente";
                        }
                        else
                        {
                            ViewBag.Message = "Se produjo un error al actualizar el registro del empleado";
                        }
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
            //ServiceReferenceEmpleado.EmpleadoServiceClient service = new ServiceReferenceEmpleado.EmpleadoServiceClient();
            //var result = service.Delete(numeroEmpleado);
            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = numeroEmpleado;
            //Llamando servicios REST

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var deleteTask = client.DeleteAsync(client.BaseAddress +"empleado/"+ empleado.NumeroEmpleado);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado correctamente al usuario";
                }
                else
                {
                    ViewBag.Message = "No se ha podido eliminar al usuario";
                }
            }
            return PartialView("Modal");
        }

    }
}
