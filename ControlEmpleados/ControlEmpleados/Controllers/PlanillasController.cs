using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEmpleados.Controllers
{
    public class PlanillasController : Controller
    {
        private readonly IPlanillasModel _planillasModel;

        public PlanillasController(IPlanillasModel planillasModel)
        {
            _planillasModel = planillasModel;
        }

        [FiltroValidarAdmin]
        public IActionResult ConsultarPlanillas()
        {
            try
            {
                var datos = _planillasModel.ConsultarPlanillas();
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
