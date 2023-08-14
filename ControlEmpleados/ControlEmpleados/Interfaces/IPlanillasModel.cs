using ControlEmpleados.Consults;
using ControlEmpleados.Entities;


namespace ControlEmpleados.Interfaces
{
    public interface IPlanillasModel
    {
        public List<ConsultarPlanillas>? ConsultarPlanillas();
        public int AgregarPlanilla(Planilla entidad);
        public int EditarPlanilla(Planilla entidad);
        public List<Planilla>? ConsultarPlanillas2();
    }
}
