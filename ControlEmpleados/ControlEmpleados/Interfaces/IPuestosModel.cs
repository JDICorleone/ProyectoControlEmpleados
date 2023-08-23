using ControlEmpleados.Entities;

namespace ControlEmpleados.Interfaces
{
    public interface IPuestosModel
    {
        public List<Puestos>? ConsultarPuestos();

        public int AgregarPuesto(Puestos entidad);

        public int EditarPuesto(Puestos entidad);
    }
}
