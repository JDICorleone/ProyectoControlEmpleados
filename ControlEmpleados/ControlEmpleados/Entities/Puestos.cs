using System.ComponentModel.DataAnnotations;

namespace ControlEmpleados.Entities
{
    public class Puestos
    {
        [Key]
        public int ID_PUESTO { get; set; }
        [Display(Name = "Nombre del puesto")]
        [Required(ErrorMessage = "Debe completar este campo.")]
        public string NOMBRE_PUESTO { get; set; } = string.Empty;


    }
}
