using DDD_CommunitySystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD_CommunitySystem.Domain.Entity;

namespace DDD_CommunitySystem.Infrastructure.Repository
{
    public class FriendsApplyRepository : IFriendsApplyRepository
    {
        public void Add(FriendsApply apply)
        {
            return;
        }

        public FriendsApply Get(Guid applyId)
        {
            throw new NotImplementedException();
        }

        public void Update(FriendsApply apply)
        {
            throw new NotImplementedException();
        }
    }
}
