using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string HORARIO { get; set; } = string.Empty;
        public string PERIODO_DE_PAGO { get; set; } = string.Empty;
        public string NOMBRE_PUESTO { get; set; } = string.Empty;
        public string ESTADO { get; set; } = string.Empty;



        [NotMapped]
        public int ID_HORARIO { get; set; }
        [NotMapped]
        public int ID_PERIODO { get; set; }
        [NotMapped]
        public int ID_ROL { get; set; }
        [NotMapped]
        public int ID_PUESTO { get; set; }
        [NotMapped]
        public int ID_ESTADO { get; set; }

    }
}
