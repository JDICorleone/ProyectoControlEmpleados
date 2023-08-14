
namespace ControlEmpleados.Consults
{
    public class ConsultarPlanillas
    {

        public int ID_PLANILLA { get; set; }
        public DateTime FECHA { get; set; }
        public int ID_EMPLEADO { get; set; }
        public int HORAS_EXTRAS { get; set; }
        public string? DEDUCCIONES { get; set; }
        public int SALARIO_NETO { get; set; }
    }
}
