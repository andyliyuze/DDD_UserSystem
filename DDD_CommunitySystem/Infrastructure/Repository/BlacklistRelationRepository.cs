using DDD_CommunitySystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD_CommunitySystem.Domain.Entity;

namespace DDD_CommunitySystem.Infrastructure.Repository
{
    public class BlacklistRelationRepository : IBlacklistRelationRepository
    {
        public void Add(BlacklistRelationship blacklistRelationship)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlacklistRelationship> Get(Guid userId)
        {
            throw new NotImplementedException();
        }

        public BlacklistRelationship Get(Guid applicanUsertId, Guid receiverUserId)
        {
            return null;
        }

        public void Update(BlacklistRelationship blacklistRelationshipId)
        {
            throw new NotImplementedException();
        }
    }
}
