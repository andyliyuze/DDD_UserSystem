using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Service;
using DDD_CommunitySystem.Domain.ValueObject;
using System;

namespace DDD_CommunitySystem.Domain.Rule.Interfac
{
    public interface ICreateFriendsApplyBeforeRule
    {

        CreateFriendApplyRepond verify(Guid applicantUserId, Guid receiverUserId, FriendsApplyService service);
    }
}
