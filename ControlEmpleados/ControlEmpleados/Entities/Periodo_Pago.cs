using System.ComponentModel.DataAnnotations;

namespace ControlEmpleados.Entities
{
    public class Periodo_Pago
    {
        [Key]
        public int ID_PERIODO { get; set; }

        public string PERIODO_DE_PAGO { get; set; } = string.Empty;


    }
}
