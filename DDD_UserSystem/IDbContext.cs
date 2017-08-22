using System.Threading.Tasks;

namespace DDD_UserSystem
{
    //表示仓储的接口
    public  interface IDbContext
    {

       void RegisterNew<TEntity>(TEntity entity)
          where TEntity : class;

        void RegisterDirty<TEntity>(TEntity entity)
            where TEntity : class;

        void RegisterClean<TEntity>(TEntity entity)
            where TEntity : class;

        void RegisterDeleted<TEntity>(TEntity entity)
            where TEntity : class;
        int Commit();

        int verson { get; set; }
    }



    public interface IUnitOfWork
    {
        void BeginTransaction();

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        Task<bool> RegisterNew<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> RegisterDirty<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> RegisterClean<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> RegisterDeleted<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> CommitAsync();

        void Rollback();
    }
}
