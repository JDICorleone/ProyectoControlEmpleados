using ControlEmpleados.Consults;
using ControlEmpleados.Entities;
using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadosModel _empleadosModel;
        private readonly IUsuariosModel _usuariosModel;
        private readonly IPuestosModel _puestosModel;

        public EmpleadosController(IEmpleadosModel empleadosModel, IUsuariosModel usuariosModel, IPuestosModel puestosModel)
        {
            _empleadosModel = empleadosModel;
            _usuariosModel = usuariosModel;
            _puestosModel = puestosModel;
        }

        [FiltroValidarAdmin]
        public IActionResult ConsultarEmpleados()
        {
            try
            {
                var datos = _empleadosModel.ConsultarEmpleados();
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [FiltroValidarAdmin]
        public IActionResult AgregarEmpleado()
        {
            try
            {
                var usuarios = _usuariosModel.ConsultarUsuarios();

                var empleados = _empleadosModel.ConsultarEmpleados();

                var puestos = _puestosModel.ConsultarPuestos();

                ViewBag.Puestos = puestos;

                ViewBag.Empleados = empleados;

                ViewBag.Usuarios = usuarios;

                int idEmpleado = int.Parse(HttpContext.Session.GetString("idEmpleadoSession").ToString());

                if (idEmpleado == 0)
                {

                    var entidad = new Empleado();

                    return View(entidad);
                }
                else
                {
                    var empleado = _empleadosModel.ConsultarEmpleados2().FirstOrDefault(x => x.ID_EMPLEADO == idEmpleado);


                    return View(empleado);
                }

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



        [HttpPost]
        public IActionResult AgregarEmpleado(Empleado entidad)
        {
            try
            {
                int idEmpleado = int.Parse(HttpContext.Session.GetString("idEmpleadoSession").ToString());

                entidad.ID_EMPLEADO = idEmpleado;

                var usuarios = _usuariosModel.ConsultarUsuarios();

                var empleados = _empleadosModel.ConsultarEmpleados();

                var puestos = _puestosModel.ConsultarPuestos();

                ViewBag.Puestos = puestos;

                ViewBag.Empleados = empleados;

                ViewBag.Usuarios = usuarios;

                if (idEmpleado == 0)
                {
                    entidad.ID_ESTADO = 1;

                    var resultado = _empleadosModel.AgregarEmpleado(entidad);

                    if (resultado > 0)
                    {
                        ViewBag.mensaje = "OK";
                        return View(entidad);
                    }
                    else
                    {
                        ViewBag.mensaje = "ERROR";
                        return View();
                    }
                }
                else {

                    ViewBag.mensaje = "OK.";

                    var empleado = _empleadosModel.ConsultarEmpleados2().FirstOrDefault(x => x.ID_EMPLEADO == idEmpleado);

                    _empleadosModel.EditarEmpleado(entidad);

                    return View(empleado);

                }

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult CargarIngreso(int idEmpleado)
        {
            try
            {
                HttpContext.Session.SetString("idEmpleadoSession", idEmpleado.ToString());
                return Json(idEmpleado);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

    }
}
