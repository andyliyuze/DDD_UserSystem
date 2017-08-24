using DDD_CommunitySystem.Domain.Entity;
using System;

namespace DDD_CommunitySystem.Domain.Repository
{
    public  interface IFriendsApplyRepository : IRepository
    {
        FriendsApply Get(Guid applyId);
        void Add(FriendsApply apply);
        void Update(FriendsApply apply);
    }
}
