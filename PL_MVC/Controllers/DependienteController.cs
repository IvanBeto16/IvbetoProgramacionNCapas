using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DependienteController : Controller
    {
        // GET: Dependiente
        public ActionResult GetAllDependiente()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();

            empleado.Empresa.IdEmpresa = 0;
            empleado.Nombre = "";
            ML.Result result = BL.Empleado.GetAllEF(empleado);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(empleado);
        }

        [HttpPost]
        public ActionResult GetAllDepentiente(ML.Empleado empleado)
        {
            if(empleado.Nombre == null) 
            {
                empleado.Nombre = "";
            }
            if(empleado.Empresa.IdEmpresa != 0)
            {
                empleado.Empresa.IdEmpresa = 0;
            }
            ML.Result result = BL.Empleado.GetAllEF(empleado);
            empleado.Empresa = new ML.Empresa();
            
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;

            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }

            return View(empleado);
        }

        // GET: Dependiente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dependiente/Edit/5
        [HttpGet]
        public ActionResult DependienteGetByEmpleado(string numeroEmpleado)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            dependiente.Empleado = new ML.Empleado();
            dependiente.Empleado.NumeroEmpleado = numeroEmpleado;
            ML.Result result = BL.Dependiente.GetByIdEmpleado(dependiente.Empleado.NumeroEmpleado);
            if (result.Correct)
            {
                dependiente.Dependientes = result.Objects;
            }
            return View(dependiente);
        }

        // GET: Dependiente/Edit/5
        public ActionResult Form(string numeroEmpleado, int? idDependiente)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            dependiente.Empleado = new ML.Empleado();
            dependiente.Empleado.NumeroEmpleado = numeroEmpleado;

            if(idDependiente == 0) //Add
            {
                dependiente.Accion = "Add";
            }
            else  //Update
            {
                //Unboxing
                ML.Result resultDependientes = BL.Dependiente.GetById(idDependiente.Value);
                dependiente = (ML.Dependiente)resultDependientes.Object; //Excepcion de casteo al insertar
                dependiente.Accion = "Update";
            }

            return View(dependiente);
        }

        // POST: Dependiente/Edit/5
        [HttpPost]
        public ActionResult Form(ML.Dependiente dependiente)
        {
            if(dependiente.Accion == "Add") //hora de comida volvemos
            {
                //Add
                ML.Result result = BL.Dependiente.AddEF(dependiente);
                if (result.Correct)
                {
                    ViewBag.numEmpleado = dependiente.Empleado.NumeroEmpleado;
                    return RedirectToAction("DependienteGetByEmpleado", "Dependiente", new { dependiente.Empleado.NumeroEmpleado });
                }
                else
                {
                    ViewBag.Message = "Error al insertar el dependiente nuevo";
                    ViewBag.numEmpleado = dependiente.Empleado.NumeroEmpleado;
                    return PartialView("Modal");
                }
            }
            else
            {
                //Update
                ML.Result result = BL.Dependiente.UpdateEF(dependiente);
                if (result.Correct)
                {
                    ViewBag.numEmpleado = dependiente.Empleado.NumeroEmpleado;
                    return RedirectToAction("DependienteGetByEmpleado", "Dependiente", new { dependiente.Empleado.NumeroEmpleado });
                }
                else
                {
                    ViewBag.Message = "Error al actualizar el dependiente nuevo";
                    ViewBag.numEmpleado = dependiente.Empleado.NumeroEmpleado;
                    return PartialView("Modal");
                }
            }
        }

        // GET: Dependiente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dependiente/Delete/5
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
