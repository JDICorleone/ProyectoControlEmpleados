using ControlEmpleados.Entities;
using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControlEmpleados.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuariosModel _usuariosModel;
        public HomeController(ILogger<HomeController> logger, IUsuariosModel usuariosModel)
        {
            _logger = logger;
            _usuariosModel = usuariosModel;
        }

        [FiltroValidarSesion]
        public IActionResult Index()
        {
            return View();
        }
        [FiltroValidarSesion]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                HttpContext.Session.Clear();
                return View();
            }
            catch
            {
                return View("Error");
            }

        }

        [HttpPost]
        public IActionResult Login(Usuario entidad)
        {
            try
            {
                var resultado = _usuariosModel.ValidarUsuario(entidad);
                if (resultado != null)
                {
                    //Roles RH y TI tienen una variable de sesión "ADMIN".
                    if (resultado.ID_ROL == 2 || resultado.ID_ROL == 3)
                    {
                        
                        HttpContext.Session.SetString("ADMIN", resultado.ID_ROL.ToString());
                    }
                    HttpContext.Session.SetString("CORREO", resultado.CORREO);

                    HttpContext.Session.SetString("ID", resultado.ID_USUARIO.ToString());

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.mensaje = "Alerta";
                    return View();
                }
            }
            catch
            {
                return View("Error");
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}