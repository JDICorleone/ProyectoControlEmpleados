using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlEmpleados.Controllers
{
    public class PlanillaController : Controller
    {
        private readonly IPlanillasModel _planillasModel;
        public PlanillaController(IPlanillasModel planillasModel)
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
