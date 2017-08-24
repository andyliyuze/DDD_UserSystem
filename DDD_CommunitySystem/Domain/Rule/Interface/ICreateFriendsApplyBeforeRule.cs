using DDD_CommunitySystem.Domain.ValueObject;
using System;

namespace DDD_CommunitySystem.Domain.Rule.Interfac
{
    public    interface ICreateFriendsApplyBeforeRule
    {

        CreateFriendApplyRepond verify(Guid applicantUserId, Guid receiverUserId);
    }
}
