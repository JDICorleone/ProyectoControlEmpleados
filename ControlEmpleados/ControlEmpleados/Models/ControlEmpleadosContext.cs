using Microsoft.EntityFrameworkCore;

namespace ControlEmpleados.Models
{
    public class ControlEmpleadosContext : DbContext
    {
        public ControlEmpleadosContext(DbContextOptions<ControlEmpleadosContext> opciones)
        : base(opciones)
        {
        }
        //Entidades o las tables de la DB
        public DbSet<Empleado> Empleado { get; set; }
    }
}
