using ControlEmpleados.Entities;
using ControlEmpleados.Filters;
using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlEmpleados.Controllers
{
    public class SolicitudVacacionesController : Controller
    {
        private readonly ISolicitudVacacionesModel _solicitudVacacionesModel;
        private readonly IEmpleadosModel _empleadosModel;

        public SolicitudVacacionesController(ISolicitudVacacionesModel solicitudVacacionesModel, IEmpleadosModel empleadosModel)
        {
            _solicitudVacacionesModel = solicitudVacacionesModel;
            _empleadosModel = empleadosModel;
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

        [HttpGet]
        public IActionResult AgregarSolicitud() {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarSolicitud(Solicitud_Vacaciones entidad)
        {
            try
            {
                int idUsuario = int.Parse(HttpContext.Session.GetString("ID").ToString());

                var empleado = _empleadosModel.ConsultarEmpleados2().FirstOrDefault(x => x.ID_USUARIO == idUsuario);

                entidad.ID_EMPLEADO = empleado.ID_EMPLEADO;

                int cantidadDias = _solicitudVacacionesModel.cantidadVacaciones(entidad.FECHA_INICIO,entidad.FECHA_FINAL);

                entidad.CANTIDAD_DIAS = cantidadDias;
                entidad.ESTADO = "Pendiente";
                entidad.ID_SOLICITUD_VACACIONES = 0;

                var resultado = _solicitudVacacionesModel.AgregarSolicitud(entidad);

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
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult MisSolicitudes()
        {
            try
            {
                int idUsuario = int.Parse(HttpContext.Session.GetString("ID").ToString());

                var empleado = _empleadosModel.ConsultarEmpleados2().FirstOrDefault(x => x.ID_USUARIO == idUsuario);

                var idempleado = empleado.ID_EMPLEADO;


                var datos = _solicitudVacacionesModel.ConsultarSolicitudesEmpleado(idempleado);
                return View(datos);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
