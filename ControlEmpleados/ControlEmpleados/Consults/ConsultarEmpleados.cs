using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ControlEmpleados.Consults
{
    public class ConsultarEmpleados
    {

        public int ID_EMPLEADO { get; set; }
 
        public string? NOMBRE { get; set; }
  
        public string? PRIMER_APELLIDO { get; set; }

        public string? SEGUNDO_APELLIDO { get; set; }
        public int CEDULA { get; set; }

        public string HORARIO { get; set; } = string.Empty;
        public string PERIODO_DE_PAGO { get; set; } = string.Empty;
        public string NOMBRE_PUESTO { get; set; } = string.Empty;
        public string ESTADO { get; set; } = string.Empty;

        public int PAGO_POR_HORA { get; set; }
        public int VACACIONES_DISPONIBLES { get; set; }
        public DateTime FECHA_DE_INGRESO { get; set; }



    }
}
