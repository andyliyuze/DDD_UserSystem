using DDD_CommunitySystem.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Abp.Dependency;
using Abp.Events.Bus;
using System.Reflection;
using Abp.Modules;
using Abp;
using System.Collections.Generic;
using DDD_CommunitySystem.Infrastructure;

namespace UnitTest
{
    [TestClass()]
    public class FriendsApply_Test 
    {
        private IEventBus obj2;
        private IUnitOfWork _unitofwork;
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
            LocalIocManager.Register<IUnitOfWork, Unitofwork>(DependencyLifeStyle.Singleton);
            LocalIocManager.Register<IDbContext, CommunityContext>(DependencyLifeStyle.Singleton);
            var otherModule = LocalIocManager.Resolve<MyModule>();         
            obj2 = LocalIocManager.Resolve<IEventBus>();
            _unitofwork= LocalIocManager.Resolve<IUnitOfWork>();
           var context= LocalIocManager.Resolve<IDbContext>();
            context.verson = 1;
        }

        [TestMethod()]
        public void PassApply_Test_()
        {
            FriendsApply apply = new FriendsApply(Guid.NewGuid(), Guid.NewGuid());
           apply.EventBus = obj2;
            apply.PassApply();
            _unitofwork.Commit();
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
