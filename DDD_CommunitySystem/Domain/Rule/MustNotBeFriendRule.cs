using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Rule.Interfac;
using DDD_CommunitySystem.Domain.ValueObject;
using System;

namespace DDD_CommunitySystem.Domain.Rule
{
    public class MustNotBeFriendRule : ICreateFriendsApplyBeforeRule
    {
        private IFriendshipRepository _friendshipRepository;
        public MustNotBeFriendRule(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }
        public CreateFriendApplyRepond verify(Guid applicantUserId, Guid receiverUserId)
        {
            if (_friendshipRepository.Get(applicantUserId, receiverUserId) != null)
            { return new CreateFriendApplyRepond() { Result = CreateFriendApplyResult.faild, FaildReason = FaildReason.BeFriend }; }
            return new CreateFriendApplyRepond() { Result = CreateFriendApplyResult.succeed };
        }
    }
}
