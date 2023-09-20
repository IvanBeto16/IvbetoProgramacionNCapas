using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet] //[Decorador], Para mostrar una vista o un recurso
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            if(usuario.Nombre == null)
            {
                usuario.Nombre = "";

            }if(usuario.ApellidoPaterno == null)
            {
                usuario.ApellidoPaterno = "";
            }
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            usuario = new ML.Usuario();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(usuario);
        }


        [HttpGet] //[Decorador]
        public ActionResult Form(int? IdUsuario)
        {
            //Instancias para mostrar los datos de roles y direccion
            //y el propio usuario
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            ML.Result resultRoles = BL.Rol.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();

            if(IdUsuario == null) //Add
            {
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                usuario.Rol.Roles = resultRoles.Objects;
            }
            else //Update
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultRoles.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais.Value).Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado.Value).Objects;
                    usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio.Value).Objects;
                }
            }
            return View(usuario);
        }

        [HttpPost] //[Decorador], Para insertar información
        public ActionResult Form(ML.Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (file.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirABase64(file);
                }
                if (usuario.IdUsuario == 0) //Add
                {
                    ML.Result result = BL.Usuario.AddEF(usuario);
                    if (result.Correct)
                    {
                        //Viewbag sirve para enviar tipo de dato de un controlador a una vista
                        ViewBag.Message = "Se ha agregado correctamente el usuario";
                    }
                    else
                    {
                        ViewBag.Message = result.ErrorMessage;
                    }
                }
                else  //Update
                {
                    ML.Result result = BL.Usuario.UpdateEF(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Message = "Se ha actualizado correctamente el usuario";
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
                
                usuario.Rol = new ML.Rol();
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                ML.Result resultRoles = BL.Rol.GetAll();
                ML.Result resultPais = BL.Pais.GetAll();

                usuario.Rol.Roles = resultRoles.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                //usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais.Value).Objects;
                //usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado.Value).Objects;
                //usuario.Direccion.Colonia.Colonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio.Value).Objects;
                return View(usuario);
            }
        }

        public ActionResult Delete(int IdUsuario)
        {

            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);
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

        //Metodos para poder actualizar secciones sin recargar la pagina
        //Se regargan elementos de dropdownlist de estados, municipios y colonias
        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }

        //Metodos para poder hacer uso de la baja logica de los usuarios
        [HttpPost]
        public JsonResult ChangeStatus(int IdUsuario, bool Status)
        {
            ML.Result result = BL.Usuario.ChangeStatus(IdUsuario, Status);
            return Json(null);
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            ML.Result result = BL.Usuario.Login(email, password);
            ML.Usuario usuario = (ML.Usuario)result.Object; //Expepcion de casteo invalido System.Object ->/ ML.Usuario
            if (result.Correct)
            {   
                //Unboxing
                if(usuario.Email == email && usuario.Password == password)
                {
                    ViewBag.Message = "Usuario y Contraseña Correctos. Bienvenido";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Correo y/o Contraseña incorrectos, rectifique y vuelva a ingresa los datos";
                    return PartialView("Modal");
                }
            }
            return PartialView("Modal");
        }

    }
}