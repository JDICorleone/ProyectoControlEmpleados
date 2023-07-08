using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ControlEmpleadosContext _context;

        public EmpleadoController(ControlEmpleadosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Empleado.ToListAsync());
        }
    }
}
