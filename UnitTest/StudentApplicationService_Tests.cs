using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using UserDomain;
using DDD_UserSystem.ApplicationService;
using DDD_UserSystem.Infrastructure;
using DDD_UserSystem.Data.EF.DataModel;
using DDD_UserSystem.Data.EF;
using DDD_CommunitySystem.Infrastructure.Cache;
using DDD_CommunitySystem.Domain.Rule;
using DDD_CommunitySystem.Domain.Rule.Interfac;

namespace UnitTest
{
    [TestClass()]
    public class StudentApplicationService_Tests
    {
 
        private IStudentApplicationService _service;
        public StudentApplicationService_Tests()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<EntLibCacheProvider>().As<ICacheProvider>().SingleInstance();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            //一次生命周期中该组件实例是唯一的，即共享
            builder.RegisterType<UserContext>().As<IDbContext>().SingleInstance();
            builder.RegisterType<Unitofwork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<StudentApplicationService>().As<IStudentApplicationService>().SingleInstance();
        
            //在单个scope实例中该组件是共享的，但在不同scope中该组件就会不一样
            //builder.RegisterType<UserContext>().As<IDbContext>().InstancePerLifetimeScope();
            var container = builder.Build();
            var scope = container.BeginLifetimeScope();      
            _service = scope.Resolve<IStudentApplicationService>();  
            DataMapConfig.MapConfig();
        }
        [TestMethod()]
        public void RemoveSingleConatct_Test_()
        {
            _service.RemoveSingleConatct(Guid.Parse("702398F2-3CC7-4D51-9CE7-5458E42D4035"), Guid.Parse("76531CB4-0E91-4EA4-B0F2-879326244802"));
        }
        [TestMethod()]
        public void AddContact_Test_()
        {
            _service.AddContact(Guid.Parse("76531cb4-0e91-4ea4-b0f2-879326244802"), 123456, 123);
        }

        [TestMethod()]
        public void AddStudent_Test_()
        {
            Guid UserId = Guid.NewGuid();
            List<ContactDataModel> contacts = new List<ContactDataModel>();
            contacts.Add(new ContactDataModel() { ContactId = Guid.NewGuid(), Phone = 1231312313, QQ = 12312312, UserId = UserId });
            var stu = new StudentDataModel() { ID = UserId, Age = "123", Detail = "1sss", LoginName = "liyuze", Password = "Andy", RealName = "李雨泽", Contry = "chaina", Contacts=contacts };
            _service.AddStudent(stu);
        }
    }
}
