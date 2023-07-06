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
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
