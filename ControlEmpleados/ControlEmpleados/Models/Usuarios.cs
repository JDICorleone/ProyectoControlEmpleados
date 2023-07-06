using System.ComponentModel.DataAnnotations;

namespace ControlEmpleados.Models
{
    public class Usuarios
    {
        [Key]
        public int ID_USUARIO { get; set; }

        public string? NOMBRE { get; set; }

        public string? APELLIDOS { get; set; }

        public int CEDULA { get; set; }

        public string? CORREO { get; set; }

        public int ID_HORARIO { get; set; }

        public int PAGO_POR_HORA { get; set; }

        public int ID_PEDIODO { get; set; }

        public int ID_ROL { get; set; }

        public int VACACIONES_DISPONIBLES { get; set; }

        public int ID_ESTADO { get; set; }
    }
}
