using ControlEmpleados.Consults;
using ControlEmpleados.Entities;

namespace ControlEmpleados.Interfaces
{
    public interface IUsuariosModel
    {

        public Usuario? ValidarUsuario(Usuario entidad);
        public int RecuperarContrasenna(Usuario entidad);

        public List<ConsultarUsuarios>? ConsultarUsuarios();

        public int AgregarUsuario(Usuario entidad);

        public int EditarUsuario(Usuario entidad);

        public List<Usuario>? ConsultarUsuarios2();

        public bool CorreoExiste(Usuario entidad);
    }
}
