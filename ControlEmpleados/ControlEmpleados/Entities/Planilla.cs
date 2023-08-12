using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ControlEmpleados.Entities
{
    public class Planilla
    {
        [Key]
        public int ID_PLANILLA { get; set; }
        [Display(Name = "ID Planilla")]
        public DateTime FECHA { get; set; }
        public int ID_EMPLEADO { get; set; }
        [Display(Name = "ID Empleado")]
        public int HORAS_EXTRAS { get; set; }
        [Display(Name = "Horas Extras")]
        public string DEDUCCIONES { get; set; }
        [Display(Name = "Deducciones")]
        public int SALARIO_NETO { get; set; }
        [Display(Name = "Salario Neto")]


        public string HORARIO { get; set; } = string.Empty;
        public string PERIODO_DE_PAGO { get; set; } = string.Empty;
        public string NOMBRE_PUESTO { get; set; } = string.Empty;
        public string ESTADO { get; set; } = string.Empty;



       // [NotMapped]
       // public int ID_HORARIO { get; set; }
       // [NotMapped]
       // public int ID_PERIODO { get; set; }
       // [NotMapped]
       // public int ID_ROL { get; set; }
       // [NotMapped]
       // public int ID_PUESTO { get; set; }
        // [NotMapped]
       // public int ID_ESTADO { get; set; }

    
    }
}
