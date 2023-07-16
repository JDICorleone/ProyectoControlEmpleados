using System.ComponentModel.DataAnnotations;

namespace ControlEmpleados.Models
{
    public class Usuario
    {
        [Key]
        public int ID_USUARIO { get; set; }
        [Display(Name = "Correo Electrónico")]
        public string? CORREO { get; set; }
        [Display(Name = "Contraseña")]
        public string? CONTRASEÑA { get; set; }
        [Display(Name = "Rol de Usuario")]
        public int ID_ROL { get; set; }
    }
}
