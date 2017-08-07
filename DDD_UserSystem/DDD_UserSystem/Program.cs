using Autofac;
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
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IStudentRepository>();
                StudentApplicationService applicationservice = new StudentApplicationService(service);
                applicationservice.ChangePassword(Guid.NewGuid(), "123", "123");
            }
        }
    }
}
