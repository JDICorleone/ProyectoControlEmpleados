﻿using ControlEmpleados.Entities;

namespace ControlEmpleados.Interfaces
{
    public interface IUsuariosModel
    {

        public Usuario? ValidarUsuario(Usuario entidad);
    }
}
