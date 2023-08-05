using System.ComponentModel.DataAnnotations;

namespace ControlEmpleados.Entities
{
    public class Puestos
    {
        [Key]
        public int ID_PUESTO { get; set; }

        public string NOMBRE_PUESTO { get; set; } = string.Empty;


    }
}
