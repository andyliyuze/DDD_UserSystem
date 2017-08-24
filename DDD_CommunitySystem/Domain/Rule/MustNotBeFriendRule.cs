using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Rule.Interfac;
using DDD_CommunitySystem.Domain.Service;
using DDD_CommunitySystem.Domain.ValueObject;
using System;

namespace DDD_CommunitySystem.Domain.Rule
{
    public class MustNotBeFriendRule : ICreateFriendsApplyBeforeRule
    {
      
         
        
        public   CreateFriendApplyRepond verify(Guid applicantUserId, Guid receiverUserId, FriendsApplyService service)
        {
            if (service.IsBeFriend(applicantUserId,receiverUserId))
            { return new CreateFriendApplyRepond() { Result = CreateFriendApplyResult.faild, FaildReason = FaildReason.BeFriend }; }
            return new CreateFriendApplyRepond() { Result = CreateFriendApplyResult.succeed };
        }
    }
}
