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
                int idUsuario = int.Parse(HttpContext.Session.GetString("idUsuarioSession").ToString());

                if (idUsuario == 0)
                {

                    var entidad = new Usuario();

                    return View(entidad);
                }
                else
                {
                    var usuario = _usuariosModel.ConsultarUsuarios2().FirstOrDefault(x => x.ID_USUARIO == idUsuario);


                    return View(usuario);
                }
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
                bool correoExiste = _usuariosModel.CorreoExiste(entidad);

                int idUsuario = int.Parse(HttpContext.Session.GetString("idUsuarioSession").ToString());
                entidad.ID_USUARIO = idUsuario;

                if (idUsuario == 0)
                {
                    if (correoExiste)
                    {
                        ViewBag.Alerta = "ERROR";
                        return View(entidad);
                    }
                    else {
                        var resultado = _usuariosModel.AgregarUsuario(entidad);
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
                }
                else
                {
                    ViewBag.mensaje = "OK.";

                    var usuario = _usuariosModel.ConsultarUsuarios2().FirstOrDefault(x => x.ID_USUARIO == idUsuario);

                    _usuariosModel.EditarUsuario(entidad);

                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        public ActionResult CargarIngreso(int idUsuario)
        {
            try
            {
                HttpContext.Session.SetString("idUsuarioSession", idUsuario.ToString());
                return Json(idUsuario);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

    

    }
}
