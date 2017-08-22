using DDD_UserSystem.Data.EF.DataModel;
using System.Data.Entity;
using System.Reflection;
using UserDomain;
using System;
using System.Threading.Tasks;

namespace DDD_UserSystem
{
    public class UserContext : DbContext, IDbContext
    {

        public UserContext()
            : base("UserDDD")
        {
            //调试开发使用，每次都会先删除数据库再创建
         //   Database.SetInitializer<UserContext>(new DropCreateDatabaseAlways<UserContext>());

        }
        public DbSet<Student> Student { get; set; }
       public DbSet<ContactDataModel> Contacts { get; set; }
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
            modelBuilder.ComplexType<Address>();
            modelBuilder.ComplexType<LoginInfo>();      
            modelBuilder.Entity<Student>().Ignore(t => t.Contacts);
            modelBuilder.Entity<ContactDataModel>().ToTable("Contacts");
      
          //  modelBuilder.Entity<Student>() 
          //        .Map(m =>
          //        {
          //            m.Properties(t => new { t.UserId, t.RealName, t.LoginInfo, t.IQ, t.Grade, t.Age, t.Address });
          //            m.ToTable("Student");
          //        })
          //  .Map(m =>
          //  {
          //      m.Properties(t => new { t.Contacts });
          //      m.ToTable("Contacts");
          //  }) 
          //;



          


        }

        public void RegisterNew<TEntity>(TEntity entity) where TEntity : class
        {
            base.Set<TEntity>().Add(entity);

        }

        public void RegisterDirty<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Modified;
        
        }

        public  void RegisterClean<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Unchanged;

        }

        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            base.Set<TEntity>().Remove(entity);

        }
    }
}
