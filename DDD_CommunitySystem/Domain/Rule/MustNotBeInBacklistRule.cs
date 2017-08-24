using System;
using DDD_CommunitySystem.Domain.ValueObject;
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Rule.Interfac;

namespace DDD_CommunitySystem.Domain.Rule
{
    public class MustNotBeInBacklistRule : ICreateFriendsApplyBeforeRule
    {

        private IBlacklistRelationRepository _blacklistRelationRepository;

        public MustNotBeInBacklistRule(IBlacklistRelationRepository blacklistRelationRepository) { _blacklistRelationRepository = blacklistRelationRepository; }
        public CreateFriendApplyRepond verify(Guid applicantUserId, Guid receiverUserId)
        {
            if (_blacklistRelationRepository.Get(applicantUserId, receiverUserId) !=null)
            { return new CreateFriendApplyRepond() { Result = CreateFriendApplyResult.faild ,FaildReason=FaildReason.BeFriend}; }
            return new CreateFriendApplyRepond() { Result = CreateFriendApplyResult.succeed };
        }
    }

  
}
