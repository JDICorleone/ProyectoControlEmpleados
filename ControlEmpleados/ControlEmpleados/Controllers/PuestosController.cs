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
                int idPuesto = int.Parse(HttpContext.Session.GetString("idPuestoSession").ToString());

                if (idPuesto == 0)
                {
                    var entidad = new Puestos();
                    return View(entidad);
                }
                else
                {
                    var puesto = _puestosModel.ConsultarPuestos().FirstOrDefault(x => x.ID_PUESTO == idPuesto);
                    return View(puesto);
                }    
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
                int idPuesto = int.Parse(HttpContext.Session.GetString("idPuestoSession").ToString());

                entidad.ID_PUESTO = idPuesto;



                if (idPuesto == 0) {

                    entidad.ID_PUESTO = 0;

                    var resultado = _puestosModel.AgregarPuesto(entidad);

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
                } else
                {
                    ViewBag.mensaje = "OK.";

                    var puesto = _puestosModel.ConsultarPuestos().FirstOrDefault(x => x.ID_PUESTO == idPuesto);

                    _puestosModel.EditarPuesto(entidad);

                    return View(puesto);
                }

                
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        public ActionResult CargarIngreso(int idPuesto)
        {
            try
            {
                HttpContext.Session.SetString("idPuestoSession", idPuesto.ToString());
                return Json(idPuesto);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
    }
}
