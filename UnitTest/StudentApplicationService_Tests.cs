using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using DDD_UserSystem;
using UserDomain;
using DDD_UserSystem.ApplicationService;

namespace UnitTest
{
    [TestClass()]
    public class StudentApplicationService_Tests
    {
 
        private IStudentApplicationService _service;
        public StudentApplicationService_Tests()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            //一次生命周期中该组件实例是唯一的，即共享
            builder.RegisterType<UserContext>().As<IDbContext>().SingleInstance();
            builder.RegisterType<StudentApplicationService>().As<IStudentApplicationService>().SingleInstance();
            //在单个scope实例中该组件是共享的，但在不同scope中该组件就会不一样
            //builder.RegisterType<UserContext>().As<IDbContext>().InstancePerLifetimeScope();
            var container = builder.Build();

            var scope = container.BeginLifetimeScope();
           
            _service = scope.Resolve<IStudentApplicationService>();
        }
        [TestMethod()]
        public void RemoveSingleConatct_Test()
        {
            _service.RemoveSingleConatct(Guid.Parse("702398F2-3CC7-4D51-9CE7-5458E42D4035"), Guid.Parse("76531CB4-0E91-4EA4-B0F2-879326244802"));
        }
    }
}
