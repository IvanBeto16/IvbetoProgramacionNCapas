using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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

            //Usaremos el Servicio web SOAP para llamar al metodo
            //ServiceReferenceAseguradora.AseguradoraServiceClient service = new ServiceReferenceAseguradora.AseguradoraServiceClient();
            //var result = service.GetAll();

            //    ML.Aseguradora seguro = new ML.Aseguradora();
            //    if (result.Correct)
            //    {
            //        seguro.Aseguradoras = result.Objects.ToList();
            //    }
            //    else
            //    {
            //        ViewBag.Message = result.ErrorMessage;
            //    }
            //    return View(seguro);

            ML.Aseguradora seguro = new ML.Aseguradora();
            seguro.Aseguradoras = new List<object>();
            //lamando al servicio de REST
            ML.Result result = new ML.Result();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var responseTask = client.GetAsync($"usuario?nombre=&apellidopaterno=");
                responseTask.Wait();

                var resultServicio = responseTask.Result;

                if (resultServicio.IsSuccessStatusCode)
                {
                    var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultUsuario in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultUsuario.ToString());
                        seguro.Aseguradoras.Add(resultItemList);
                    }
                }
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

            ML.Result result = BL.Usuario.GetAllEF(aseguradora.Usuario);
            //ML.Result resultUsuarios = BL.Usuario.GetAllEF(aseguradora.Usuario);
            //if (IdAseguradora == null) //Add
            //{
            //    aseguradora.Usuario.Usuarios = resultUsuarios.Objects;
            //}
            //else  //Update
            //{
            //    ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora.Value);
            //    if (result.Correct)
            //    {
            //        aseguradora = (ML.Aseguradora)result.Object;
            //        aseguradora.Usuario.Usuarios = resultUsuarios.Objects;
            //    }
            //}

            if (IdAseguradora != null) //Update
            {
                //Usando los servicios REST
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                    var responseTask = client.GetAsync("aseguradora/" + IdAseguradora);
                    responseTask.Wait();

                    var resultService = responseTask.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        var readTask = resultService.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Aseguradora resultSegura = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Aseguradora>(readTask.Result.Object.ToString());
                        aseguradora = resultSegura;
                    }
                }
            }
            else     //Add
            {
                aseguradora.Usuario.Usuarios = result.Objects;
            }

            return View(aseguradora);
        }

        // POST
        [HttpPost]
        public ActionResult FormAseguradora(ML.Aseguradora aseguradora)
        {
            if (aseguradora.IdAseguradora == 0) //Add
            {
                //LLamada al metodo de Add sin servicios web
                //ML.Result result = BL.Aseguradora.AddEF(aseguradora);

                //Llamada al metodo de Add con servicios web SOAP
                //ServiceReferenceAseguradora.AseguradoraServiceClient service = new ServiceReferenceAseguradora.AseguradoraServiceClient();
                //var result = service.Add(aseguradora);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                    var postTask = client.PostAsJsonAsync<ML.Aseguradora>(client.BaseAddress + "aseguradora/", aseguradora);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha ingresado correctamente la aseguradora";
                    }
                    else
                    {
                        ViewBag.Message = "Ha ocurrido un error en la insercion";
                    }
                }

            }
            else   //Update
            {
                //Llamada al metodo de Update sin servicios web
                //ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);

                //Llamada al metodo de Update con servicios web SOAP
                //ServiceReferenceAseguradora.AseguradoraServiceClient service = new ServiceReferenceAseguradora.AseguradoraServiceClient();
                //var result = service.Update(aseguradora);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                    var putTask = client.PutAsJsonAsync<ML.Aseguradora>(client.BaseAddress + "aseguradora/", aseguradora);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha actualizado correctamente la entidad";
                    }
                    else
                    {
                        ViewBag.Message = "Ha ocurrido un error en la actualizacion";
                    }
                }
            }
            return PartialView("Modal");
        }

        // GET: Aseguradora/Delete/5
        public ActionResult Delete(int idAseguradora)
        {
            //Llamada al metodo de Delete sin servicios web
            //ML.Result result = BL.Aseguradora.DeleteEF(IdAseguradora);

            //Llamada al metodo de Delete con servicios web
            //ServiceReferenceAseguradora.AseguradoraServiceClient service = new ServiceReferenceAseguradora.AseguradoraServiceClient();
            //var result = service.Delete(IdAseguradora);

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.IdAseguradora = idAseguradora;
            //Usando los servicios REST
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var deleteTask = client.DeleteAsync(client.BaseAddress +"aseguradora/" + aseguradora.IdAseguradora);
                deleteTask.Wait();
                
                var result = deleteTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado el Seguro exitosamente";
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error, no se ha podido eliminar el seguro";
                }
            }
            return PartialView("Modal");
        }
    }
}
