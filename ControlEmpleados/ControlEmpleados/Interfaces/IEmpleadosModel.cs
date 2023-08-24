using ControlEmpleados.Consults;
using ControlEmpleados.Entities;

namespace ControlEmpleados.Interfaces
{
    public interface IEmpleadosModel
    {

        public List<ConsultarEmpleados>? ConsultarEmpleados();

        public int AgregarEmpleado(Empleado entidad);

        public int EditarEmpleado(Empleado entidad);

        public List<Empleado>? ConsultarEmpleados2();

        public int ActualizarVacaciones(int id_empleado, int vacaciones_disponibles);
    }
}
