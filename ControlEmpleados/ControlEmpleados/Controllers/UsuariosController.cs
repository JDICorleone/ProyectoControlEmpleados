using ControlEmpleados.Entities;
using ControlEmpleados.Interfaces;
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
                _usuariosModel.RecuperarContrasenna(entidad);
                ViewBag.mensaje = "Alerta";
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



    }
}
