using Autofac;
using DDD_UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            //一次生命周期中该组件实例是唯一的，即共享
            builder.RegisterType<UserContext>().As<IDbContext>().SingleInstance();
            //在单个scope实例中该组件是共享的，但在不同scope中该组件就会不一样
            //builder.RegisterType<UserContext>().As<IDbContext>().InstancePerLifetimeScope();
            var container = builder.Build();
          
            using (var scope = container.BeginLifetimeScope())
            {
                
                var context = scope.Resolve<IDbContext>();
                var service = scope.Resolve<IStudentRepository>();
                context.verson = 1;
                StudentApplicationService applicationservice = new StudentApplicationService(context,service);
                var list = new List<Contact>();
                list.Add(new Contact() { ContactId = Guid.NewGuid(), Phone = 13531125 });
                var stu = new Student() { UserId = Guid.NewGuid(), Age = "123", Contacts=list };
                applicationservice.AddStudent(stu);
              //  applicationservice.ChangePassword(Guid.NewGuid(), "123", "123");
            }
            using (var scope = container.BeginLifetimeScope())
            {
                var context = scope.Resolve<IDbContext>();
                var service = scope.Resolve<IStudentRepository>();
            }
            }
    }
}
