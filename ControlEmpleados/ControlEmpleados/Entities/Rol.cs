using System.ComponentModel.DataAnnotations;

namespace ControlEmpleados.Entities
{   
    public class Rol
    {

            [Key]
            public int ID_ROL { get; set; }
            public string ROL { get; set; } = string.Empty;
        

    }
}
