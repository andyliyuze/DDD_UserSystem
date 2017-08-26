using Autofac;
using DDD_CommunitySystem.Domain.Entity;
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Service;
using DDD_CommunitySystem.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Abp.Dependency;
using Abp.Events.Bus;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Reflection;
using Abp.Modules;
using Abp;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass()]
    public class FriendsApply_Test 
    {
        private IEventBus obj2;

        private IIocManager LocalIocManager;
        public FriendsApply_Test()
        {

            //var builder = new ContainerBuilder();

            //builder.RegisterType<FriendsApplyRepository>().As<IFriendsApplyRepository>();
            //builder.RegisterType<BlacklistRelationRepository>().As<IBlacklistRelationRepository>();
            //builder.RegisterType<FriendshipRepository>().As<IFriendshipRepository>();
            //builder.RegisterType<FriendshipService>().As<FriendshipService>();
            //var container = builder.Build();

            //var scope = container.BeginLifetimeScope();

            ////var friendsApplyRepository = scope.Resolve<IFriendsApplyRepository>();
            ////var friendshiRepository = scope.Resolve<IFriendshipRepository>();
            ////var blacklistRelationRepository = scope.Resolve<IBlacklistRelationRepository>();
            //var friendshipService = scope.Resolve<FriendshipService>();
            LocalIocManager = new IocManager();           
            AbpBootstrapper abpBootstrapper = new AbpBootstrapper(LocalIocManager);
             abpBootstrapper.Initialize();          
            LocalIocManager.Register<IModuleFinder, MyTestModuleFinder>();
            var otherModule = LocalIocManager.Resolve<MyModule>();         
            obj2 = LocalIocManager.Resolve<IEventBus>();
          
        }

        [TestMethod()]
        public void PassApply_Test_()
        {
            FriendsApply apply = new FriendsApply(Guid.NewGuid(), Guid.NewGuid());
           apply.EventBus = obj2;
            apply.PassApply();
        }
    }
    public class MyTestModuleFinder : IModuleFinder
    {
        public ICollection<Type> FindAll()
        {
            return new List<Type>
                   {
                      
                       typeof (MyModule)
                   };
        }
    }

    public class MyModule : AbpModule
    {

       
        public override void Initialize()
        {
            
            IocManager.RegisterAssemblyByConvention(Assembly.LoadFrom("DDD_CommunitySystem.dll"));
        }
    }
}
