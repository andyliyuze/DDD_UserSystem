using DDD_CommunitySystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD_CommunitySystem.Domain.Entity;

namespace DDD_CommunitySystem.Infrastructure.Repository
{
    public class FriendshipRepository : IFriendshipRepository
    {
        public void Add(Friendship friendship)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friendship> Get(Guid userId)
        {
            return null;
        }

        public Friendship Get(Guid applicanUsertId, Guid receiverUserId)
        {
            return null;
        }

        public void Update(Friendship friendship)
        {
            throw new NotImplementedException();
        }
    }
}
