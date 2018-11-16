namespace PosicionesDatos
{
    public class PosicionesEntitiesRepositorio<TEntity> : GenericRepository<IPosicionesDatosContext, TEntity>
        where TEntity : class
    {
        public PosicionesEntitiesRepositorio()
        {
            _context = new PosicionesDatosContext();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
