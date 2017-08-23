using DDD_CommunitySystem.Domain.Entity;
 
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Service
{
   public class FriendsApplyService
    {

        private IFriendsApplyRepository _friendsApplyRepository;
        public FriendsApplyService(IFriendsApplyRepository friendsApplyRepository)
        {
            _friendsApplyRepository = friendsApplyRepository;
        }
        public CreateFriendApplyRepond CreateSingleFriendsApply(Guid applicantUserId,Guid receiverUserId)
        {
            
            if (IsInBacklist(applicantUserId, receiverUserId))
            {
                return new CreateFriendApplyRepond()
                {
                    Result = CreateFriendApplyResult.faild,
                    FaildReason = FaildReason.BeInBacklist
                };
            }
            if (IsFriend(applicantUserId, receiverUserId))
            {
                return new CreateFriendApplyRepond()
                {
                    Result = CreateFriendApplyResult.faild,
                    FaildReason = FaildReason.BeFriend
                };
            }
            var friendsApply = new FriendsApply(applicantUserId, receiverUserId);
            _friendsApplyRepository.Add(friendsApply);

            return new CreateFriendApplyRepond()
            {
                Result = CreateFriendApplyResult.succeed  
            };
        }


        public bool IsInBacklist(Guid applicantUserId, Guid receiverUserId) { return false; }

        public bool IsFriend(Guid applicantUserId, Guid receiverUserId) { return false; }
    }
}
