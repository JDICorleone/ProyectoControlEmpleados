using ControlEmpleados.Entities;

namespace ControlEmpleados.Interfaces
{
    public interface IPlanillasModel
    {
        public List<Planilla>? ConsultarPlanillas();
    }
}
