using Abp.Domain.Repositories;
using DDD_CommunitySystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Repository
{
   public interface IBlacklistRelationRepository: IRepository
    {


        IEnumerable<BlacklistRelationship> Get(Guid userId);
        BlacklistRelationship Get(Guid applicanUsertId, Guid receiverUserId);
        void Add(BlacklistRelationship blacklistRelationship);
        void Update(BlacklistRelationship blacklistRelationshipId);
    }
}
