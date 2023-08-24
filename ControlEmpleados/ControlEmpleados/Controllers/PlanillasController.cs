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
        private readonly IEmpleadosModel _empleadosModel;
        public PlanillasController(IPlanillasModel planillasModel, IEmpleadosModel empleadosModel)
        {
            _planillasModel = planillasModel;
            _empleadosModel = empleadosModel;
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
                int idPlanilla = int.Parse(HttpContext.Session.GetString("idPlanillaSession").ToString());

                if (idPlanilla == 0)
                {

                    var entidad = new Planilla();

                    return View(entidad);
                }
                else
                {
                    var planilla = _planillasModel.ConsultarPlanillas2().FirstOrDefault(x => x.ID_PLANILLA == idPlanilla);


                    return View(planilla);
                }
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
                //bool correoExiste = _usuariosModel.CorreoExiste(entidad);

                int idPlanilla = int.Parse(HttpContext.Session.GetString("idPlanillaSession").ToString());
                entidad.ID_PLANILLA = idPlanilla;

                if (idPlanilla == 0)
                {
                        var resultado = _planillasModel.AgregarPlanilla(entidad);
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
                    }
                else
                {
                    ViewBag.mensaje = "OK.";

                    var planilla = _planillasModel.ConsultarPlanillas2().FirstOrDefault(x => x.ID_PLANILLA == idPlanilla);

                    _planillasModel.EditarPlanilla(entidad);

                    return View(planilla);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public ActionResult CargarIngreso(int idPlanilla)
        {
            try
            {
                HttpContext.Session.SetString("idPlanillaSession", idPlanilla.ToString());
                return Json(idPlanilla);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }

        //Nuevo

        public IActionResult MisPlanillas()
        {
            try
            {
                int idUsuario = int.Parse(HttpContext.Session.GetString("ID").ToString());

                var empleado = _empleadosModel.ConsultarEmpleados2().FirstOrDefault(x => x.ID_USUARIO == idUsuario);

                var idempleado = empleado.ID_EMPLEADO;


                var datos = _planillasModel.ConsultarPlanillasEmpleado(idempleado);
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

    }
}
