using ControlEmpleados.Entities;
using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlEmpleados.Controllers
{
    public class PuestosController : Controller
    {
        private readonly IPuestosModel _puestosModel;

        public PuestosController(IPuestosModel puestosModel) {
            _puestosModel = puestosModel;
        }

        [FiltroValidarAdmin]
        public IActionResult ConsultarPuestos()
        {
            try
            {
                var datos = _puestosModel.ConsultarPuestos();
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [FiltroValidarAdmin]
        public IActionResult AgregarPuesto()
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
        public IActionResult AgregarPuesto(Puestos entidad)
        {
            try
            {
                entidad.ID_PUESTO = 0;

                var resultado = _puestosModel.AgregarPuesto(entidad);

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
