using DDD_CommunitySystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Repository
{
   public interface IFriendshipRepository
    {
        Friendship Get(Guid friendshipId);
        void Add(Friendship friendship);
        void Update(Friendship friendship);
    }
}
