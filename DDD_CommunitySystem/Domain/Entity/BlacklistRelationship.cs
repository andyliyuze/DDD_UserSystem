using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
namespace DDD_CommunitySystem.Domain.Entity
{
   public class BlacklistRelationship: Entity<Guid>
    {
       
        public Guid CreatorUserId { get; set; }
        public Guid BeIncludedUserId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
