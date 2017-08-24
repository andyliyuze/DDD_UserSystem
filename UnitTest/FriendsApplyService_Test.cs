using Autofac;
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Service;
using DDD_CommunitySystem.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            var container = builder.Build();

            var scope = container.BeginLifetimeScope();

            var friendsApplyRepository = scope.Resolve<IFriendsApplyRepository>();

            _service = new FriendsApplyService(friendsApplyRepository);
        }

        [TestMethod()]
        public void RemoveSingleConatct_Test_()
        {
            _service.CreateSingleFriendsApply(Guid.NewGuid(), Guid.NewGuid());
        }
    }
}
