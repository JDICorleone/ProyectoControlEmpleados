using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ControlEmpleados.Entities
{
    public class Empleado
    {

        [Key]
        public int ID_EMPLEADO { get; set; }
        [Display(Name = "Nombre")]
        public string? NOMBRE { get; set; }
        [Display(Name = "Primer Apellido")]
        public string? PRIMER_APELLIDO { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string? SEGUNDO_APELLIDO { get; set; }
        [Display(Name = "Cédula")]
        public int CEDULA { get; set; }
        public int PAGO_POR_HORA { get; set; }
        [Display(Name = "Vacaciones Disponibles")]
        public int VACACIONES_DISPONIBLES { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FECHA_DE_INGRESO { get; set; }

        public int ID_HORARIO { get; set; }
        public int ID_PERIODO { get; set; }
 
        public int ID_PUESTO { get; set; }

        public int ID_ESTADO { get; set; }

        public int ID_USUARIO { get; set; }





    }
}
