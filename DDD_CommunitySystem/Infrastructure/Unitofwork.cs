using System.Data.Entity;

namespace DDD_CommunitySystem.Infrastructure
{
    public class Unitofwork : IUnitOfWork
    {
        private IDbContext _dbContext;

        public Unitofwork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public void RegisterNew<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);

        }

        public void RegisterDirty<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;

        }

        public void RegisterClean<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;

        }

        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);

        }

        public int Commit()
        {
        return     _dbContext.SaveChanges();
        }
    }
}
