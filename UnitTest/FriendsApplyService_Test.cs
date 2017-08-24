using Autofac;
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Rule;
using DDD_CommunitySystem.Domain.Rule.Interfac;
using DDD_CommunitySystem.Domain.Service;
using DDD_CommunitySystem.Infrastructure.Cache;
using DDD_CommunitySystem.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass()]
    public class FriendsApplyService_Test
    {
        private FriendsApplyService _service ;
        public FriendsApplyService_Test()
        {
            var builder = new ContainerBuilder();
      
            builder.RegisterType<FriendsApplyRepository>().As<IFriendsApplyRepository>(); 
             builder.RegisterType<BlacklistRelationRepository>().As<IBlacklistRelationRepository>();
            builder.RegisterType<FriendshipRepository>().As<IFriendshipRepository>();
      
            var container = builder.Build();

            var scope = container.BeginLifetimeScope();
           
            var friendsApplyRepository = scope.Resolve<IFriendsApplyRepository>();
            var friendshiRepository = scope.Resolve<IFriendshipRepository>();
            var blacklistRelationRepository = scope.Resolve<IBlacklistRelationRepository>();
            _service = new FriendsApplyService(friendsApplyRepository, friendshiRepository, blacklistRelationRepository);
        }

        [TestMethod()]
        public void RemoveSingleConatct_Test_()
        {
            string s = "";
            Stopwatch watch1 = Stopwatch.StartNew();
            _service.CreateSingleFriendsApply(Guid.NewGuid(), Guid.NewGuid());
            watch1.Stop();
            s=watch1.Elapsed.ToString();
            watch1.Restart();
            _service.CreateSingleFriendsApply(Guid.NewGuid(), Guid.NewGuid());
            watch1.Stop();
            s = s + "    " + watch1.Elapsed.ToString();
           
            watch1.Restart();
            _service.CreateSingleFriendsApply(Guid.NewGuid(), Guid.NewGuid());
            watch1.Stop();
           s = s + "    " + watch1.Elapsed.ToString();
        }
    }
}
