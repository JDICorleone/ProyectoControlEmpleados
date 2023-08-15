using System.ComponentModel.DataAnnotations;

namespace ControlEmpleados.Entities
{
    public class Solicitud_Vacaciones
    {
        [Key]
        public int ID_SOLICITUD_VACACIONES { get; set; }

        [Display(Name = "Asunto")]
        public string? ASUNTO { get; set; }
        [Display(Name = "Descripción")]
        public string? DESCRIPCION { get; set; }
        [Display(Name = "Tipo de vacaciones")]
        public string? TIPO_VACACIONES { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime FECHA_INICIO { get; set; }
        [Display(Name = "Fecha final")]

        public DateTime FECHA_FINAL { get; set; }
        [Display(Name = "Cantidad de días")]
        public int CANTIDAD_DIAS { get; set; }
        [Display(Name = "Estado")]
        public string? ESTADO { get; set; }

        public int ID_EMPLEADO { get; set; }
    }
}
