using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ControlEmpleados.Entities
{
    public class Planilla
    {
        [Key]
        [Display(Name = "ID Planilla")]
        public int ID_PLANILLA { get; set; }
        [Display(Name = "Fecha")]
        public DateTime FECHA { get; set; }
        [Display(Name = "ID Empleado")]
        public int ID_EMPLEADO { get; set; }
        [Display(Name = "Horas Extras")]
        public int HORAS_EXTRAS { get; set; }
        [Display(Name = "Deducciones")]
        public string? DEDUCCIONES { get; set; }
        [Display(Name = "Salario Neto")]
        public int SALARIO_NETO { get; set; }



    }
}
