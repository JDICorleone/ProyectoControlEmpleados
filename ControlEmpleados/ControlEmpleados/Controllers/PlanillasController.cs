using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEmpleados.Controllers
{
    public class PlanillasController : Controller
    {
        private readonly ControlEmpleadosContext _dbContext;

        public PlanillasController(ControlEmpleadosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ConsultarPlanillas()
        {
            var planillas = _dbContext.Planilla.ToList();
            return View(planillas);
        }

    }
}
