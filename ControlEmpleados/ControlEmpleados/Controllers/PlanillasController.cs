using ControlEmpleados.Entities;
using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        [FiltroValidarAdmin]
        public IActionResult AgregarPlanilla()
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
        public IActionResult AgregarPlanilla(Planilla entidad)
        {
            try
            {
                entidad.ID_PLANILLA = 0;

                var resultado = _planillasModel.AgregarPlanilla(entidad);

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
