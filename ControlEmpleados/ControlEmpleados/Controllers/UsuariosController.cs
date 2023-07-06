using Microsoft.AspNetCore.Mvc;

namespace ControlEmpleados.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
