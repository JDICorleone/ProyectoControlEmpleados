using System.ComponentModel.DataAnnotations;

namespace ControlEmpleados.Entities
{
    public class Usuario
    {
        [Key]
        public int ID_USUARIO { get; set; }
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "Debe completar este campo.")]
        public string? CORREO { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Debe completar este campo.")]
        public string? PASSWORD{ get; set; }
        [Display(Name = "Rol de Usuario")]
        public int ID_ROL { get; set; }


    }
}
