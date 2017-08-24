using System;
using DDD_CommunitySystem.Domain.ValueObject;
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Rule.Interfac;
using DDD_CommunitySystem.Domain.Service;

namespace DDD_CommunitySystem.Domain.Rule
{
    public class MustNotBeInBacklistRule : ICreateFriendsApplyBeforeRule
    {

       
        public CreateFriendApplyRepond verify(Guid applicantUserId, Guid receiverUserId, FriendsApplyService service)
        {
            if (service.IsInBacklist(applicantUserId,receiverUserId))
            { return new CreateFriendApplyRepond() { Result = CreateFriendApplyResult.faild ,FaildReason=FaildReason.BeFriend}; }
            return new CreateFriendApplyRepond() { Result = CreateFriendApplyResult.succeed };
        }
    }

  
}
