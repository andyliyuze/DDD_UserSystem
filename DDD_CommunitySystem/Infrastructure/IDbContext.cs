using DDD_CommunitySystem.Domain.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DDD_CommunitySystem.Infrastructure
{
    //表示数据仓储的接口
    public interface IDbContext
    {
        DbSet<BlacklistRelationship> BlacklistRelationship { get; set; }
        DbSet<FriendsApply> FriendsApply { get; set; }
        DbSet<Friendship> Friendship { get; set; }
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
