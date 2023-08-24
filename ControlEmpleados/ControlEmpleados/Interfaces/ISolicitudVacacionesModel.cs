using ControlEmpleados.Consults;
using ControlEmpleados.Entities;

namespace ControlEmpleados.Interfaces
{
    public interface ISolicitudVacacionesModel
    {
        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudes();

        public List<Solicitud_Vacaciones>? ConsultarSolicitudes2();

        public int AgregarSolicitud(Solicitud_Vacaciones entidad);

        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudesEmpleado(int id);

        public int CambiarEstado(int id_solicitud, string estado);

        public int cantidadVacaciones(DateTime FECHA_INICIO, DateTime FECHA_FINAL);
    }
}
