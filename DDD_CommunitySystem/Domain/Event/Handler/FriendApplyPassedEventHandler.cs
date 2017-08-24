using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using DDD_CommunitySystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Event.Handler
{
   public class FriendApplyPassedEventHandler : IEventHandler<FriendApplyPassedEventData>, ITransientDependency
    {

        private IFriendshipRepository friendshipRepository;
        public void HandleEvent(FriendApplyPassedEventData eventData)
        {
                     
        }
    }
}
