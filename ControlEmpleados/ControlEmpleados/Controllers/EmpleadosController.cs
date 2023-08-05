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

        public EmpleadosController(IEmpleadosModel empleadosModel, IUsuariosModel usuariosModel)
        {
            _empleadosModel = empleadosModel;
            _usuariosModel = usuariosModel;
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


                ViewBag.Empleados = empleados;

                ViewBag.Usuarios = usuarios;

                return View();
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
                var usuarios = _usuariosModel.ConsultarUsuarios();

                var empleados = _empleadosModel.ConsultarEmpleados();


                ViewBag.Empleados = empleados;

                ViewBag.Usuarios = usuarios;

                entidad.ID_ESTADO = 1;

                var resultado = _empleadosModel.AgregarEmpleado(entidad);

                if (resultado > 0)
                {
                    ViewBag.mensaje = "OK";
                    return View();
                }
                else
                {
                    ViewBag.mensaje = "ERROR";
                    return View();
                }


            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
