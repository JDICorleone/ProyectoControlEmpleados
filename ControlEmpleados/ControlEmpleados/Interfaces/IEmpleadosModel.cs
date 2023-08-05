using ControlEmpleados.Consults;
using ControlEmpleados.Entities;

namespace ControlEmpleados.Interfaces
{
    public interface IEmpleadosModel
    {

        public List<ConsultarEmpleados>? ConsultarEmpleados();

        public int AgregarEmpleado(Empleado entidad);

    }
}
