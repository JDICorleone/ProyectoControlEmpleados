using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlEmpleados.Controllers
{
    public class SolicitudVacacionesController : Controller
    {
        private readonly ISolicitudVacacionesModel _solicitudVacacionesModel;

        public SolicitudVacacionesController(ISolicitudVacacionesModel solicitudVacacionesModel)
        {
            _solicitudVacacionesModel = solicitudVacacionesModel;
        }

        [FiltroValidarAdmin]
        public IActionResult ConsultarSolicitudes()
        {
            try
            {
                var datos = _solicitudVacacionesModel.ConsultarSolicitudes();
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
