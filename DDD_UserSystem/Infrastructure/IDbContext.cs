using DDD_UserSystem.Data.EF.DataModel;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using UserDomain;

namespace DDD_UserSystem.Infrastructure
{
    //表示数据仓储的接口
    public interface IDbContext
    {
        DbSet<Student> Student { get; set; }
        DbSet<ContactDataModel> Contacts { get; set; }
        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void Dispose();
        int verson { get; set; }
    }
    //工作单元接口
    public interface IUnitOfWork
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


    }
}
