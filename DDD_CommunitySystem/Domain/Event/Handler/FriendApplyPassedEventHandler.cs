using Abp.Dependency;
using Abp.Domain.Services;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using DDD_CommunitySystem.Domain.Entity;
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Event.Handler
{
   public class FriendApplyPassedEventHandler : IEventHandler<FriendsApplyPassedEventData>    , ITransientDependency
    {

        private IFriendshipService _friendshipService;

        public FriendApplyPassedEventHandler(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        public void HandleEvent(FriendsApplyPassedEventData eventData)
        {
           
           _friendshipService.BuildFriendship(eventData.applicanUsertId, eventData.receiverUserId);
        }

        

        
    }
}
