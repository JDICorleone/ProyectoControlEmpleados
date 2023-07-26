using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadosModel _empleadosModel;

        public EmpleadosController(IEmpleadosModel empleadosModel)
        {
            _empleadosModel = empleadosModel;
        }

        [FiltroValidarAdmin]
        public IActionResult ConsultarEmpleados()
        {
            try
            {
                var datos = _empleadosModel.ConsultarEmpleados();
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
