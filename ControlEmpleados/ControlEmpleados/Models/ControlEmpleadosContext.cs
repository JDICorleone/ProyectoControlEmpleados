using ControlEmpleados.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlEmpleados.Models
{
    public class ControlEmpleadosContext : DbContext
    {
        public ControlEmpleadosContext(DbContextOptions<ControlEmpleadosContext> options) : base(options)
        {
        }

        public DbSet<Planilla> Planilla { get; set; }
    }
}
