using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserDomain;

namespace DDD_UserSystem
{
  public  class UserContext : DbContext,IDbContext
    {

        public UserContext()
            : base("UserDDD")
        {


        }
        public DbSet<Student> Student { get; set; }

        public int verson
        {
            get;set;
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
        }


       
    }
}
