using DDD_CommunitySystem.Domain.Entity;
using System.Data.Entity;
using System.Reflection;

namespace DDD_CommunitySystem.Infrastructure
{
    public class CommunityContext : DbContext, IDbContext
    {

        public CommunityContext()
            : base("CommunityDDD")
        {
            //调试开发使用，每次都会先删除数据库再创建
         //   Database.SetInitializer<UserContext>(new DropCreateDatabaseAlways<UserContext>());

        }
        public DbSet<BlacklistRelationship> BlacklistRelationship { get; set; }
        public DbSet<FriendsApply> FriendsApply { get; set; }
        public DbSet<Friendship> Friendship { get; set; }
        public int verson
        {
            get;
            set;
        }

        public int Commit()
        {
            return this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(d =>
            {
                var nonPublicProperties = d.ClrType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var p in nonPublicProperties)
                {
                    d.Property(p).HasColumnName(p.Name);
                }
            });

            modelBuilder.Entity<FriendsApply>().Property(a => a.Id).HasColumnName("FriendsApplyId");
            modelBuilder.Entity<BlacklistRelationship>().Property(a => a.Id).HasColumnName("BlacklistRelationshipId");
            modelBuilder.Entity<Friendship>().Property(a => a.Id).HasColumnName("FriendshipId");



        }
    }
}
