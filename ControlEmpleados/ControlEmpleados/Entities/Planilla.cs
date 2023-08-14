using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ControlEmpleados.Entities
{
    public class Planilla
    {
        [Key]
        //[Display(Name = "ID Planilla")]
        public int ID_PLANILLA { get; set; }
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Debe completar este campo.")]
        public DateTime FECHA { get; set; }
        [Display(Name = "ID Empleado")]
        [Required(ErrorMessage = "Debe completar este campo.")]
        public int ID_EMPLEADO { get; set; }
        [Display(Name = "Horas Extras")]
        [Required(ErrorMessage = "Debe completar este campo.")]
        public int HORAS_EXTRAS { get; set; }
        [Display(Name = "Deducciones")]
        [Required(ErrorMessage = "Debe completar este campo.")]
        public string? DEDUCCIONES { get; set; }
        [Display(Name = "Salario Neto")]
        [Required(ErrorMessage = "Debe completar este campo.")]
        public int SALARIO_NETO { get; set; }



    }
}
