using Abp.Domain.Repositories;
using DDD_CommunitySystem.Domain.Entity;
using System;
using System.Collections.Generic;

namespace DDD_CommunitySystem.Domain.Repository
{
    public interface IFriendshipRepository : IRepository
    {
        
        IEnumerable<Friendship> Get(Guid userId);
        Friendship Get(Guid applicanUsertId, Guid receiverUserId);
        void Add(Friendship friendship);
        void Update(Friendship friendship);
    }
}
