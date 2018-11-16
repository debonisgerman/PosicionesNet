using System.Configuration;
using System.Data.Entity;
using PosicionesDatos;

namespace PosicionesDatos
{
    public interface IPosicionesDatosContext : IUnitOfWork
    {
        DbSet<PosicionesEntities> Posiciones { get; set; }
    }

    public class PosicionesDatosContext : DbContext, IPosicionesDatosContext
    {
        public DbSet<PosicionesEntities> Posiciones { get; set; }
     
        public PosicionesDatosContext()
            : base(ConfigurationManager.ConnectionStrings["Posiciones"].ConnectionString) { }

        public PosicionesDatosContext(string connectionString) : base(connectionString) { }
    }
}
