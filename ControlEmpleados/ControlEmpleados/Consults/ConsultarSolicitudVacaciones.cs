namespace ControlEmpleados.Consults
{
    public class ConsultarSolicitudVacaciones
    {
        public int ID_SOLICITUD_VACACIONES { get; set; }

        public string? ASUNTO { get; set; }

        public string? DESCRIPCION { get; set; }

        public string? TIPO_VACACIONES { get; set; }

        public DateTime FECHA_INICIO { get; set; }

        public DateTime FECHA_FINAL { get; set; }

        public string? ESTADO { get; set; }

        public string? NOMBRE { get; set; }

        public string? PRIMER_APELLIDO { get; set; }

        public string? SEGUNDO_APELLIDO { get; set; }

        public int CEDULA { get; set; }

        public int VACACIONES_DISPONIBLES { get; set; }
    }
}
