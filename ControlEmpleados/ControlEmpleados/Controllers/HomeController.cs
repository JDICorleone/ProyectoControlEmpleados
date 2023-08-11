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
        private readonly IEmpleadosModel _empleadosModel;
        public HomeController(ILogger<HomeController> logger, IUsuariosModel usuariosModel, IEmpleadosModel empleadosModel)
        {
            _logger = logger;
            _usuariosModel = usuariosModel;
            _empleadosModel = empleadosModel;
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
                var empleados = _empleadosModel.ConsultarEmpleados2();

                var resultado = _usuariosModel.ValidarUsuario(entidad);
                if (resultado != null)
                {
                    // Buscar el empleado correspondiente al correo ingresado
                    var idUsuarioCorrespondiente = resultado.ID_USUARIO;

                    var empleadoCorrespondiente = empleados.FirstOrDefault(e => e.ID_USUARIO == idUsuarioCorrespondiente);

                    if (empleadoCorrespondiente != null)
                    {
                        if (empleadoCorrespondiente.ID_ESTADO == 1) 
                        {
                            // Roles RH y TI tienen una variable de sesión "ADMIN".
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
                            ViewBag.mensaje = "ERROR";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.mensaje = "No se encontró un empleado correspondiente al correo ingresado.";
                        return View();
                    }
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