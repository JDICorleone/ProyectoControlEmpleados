using ControlEmpleados.Entities;
using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlEmpleados.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IUsuariosModel _usuariosModel;
       

        public UsuariosController(IUsuariosModel usuariosModel)
        {
            _usuariosModel = usuariosModel;
           
        }

        [HttpGet]
        public IActionResult RecuperarContrasenna()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult RecuperarContrasenna(Usuario entidad)
        {
            try
            {
                entidad.PASSWORD = ".";

                int resultado = _usuariosModel.RecuperarContrasenna(entidad);

                if (resultado > 0) {
                    ViewBag.mensaje = "Alerta";
                    return View();
                }
                ViewBag.mensaje = "MAL";
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

      
        [FiltroValidarAdmin]
        public IActionResult ConsultarUsuarios()
        {
            try
            {
                var datos = _usuariosModel.ConsultarUsuarios();
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }



        [HttpGet]
        [FiltroValidarAdmin]
        public IActionResult AgregarUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



        [HttpPost]
        public IActionResult AgregarUsuario(Usuario entidad)
        {
            try
            {
                
                    var resultado = _usuariosModel.AgregarUsuario(entidad);

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
