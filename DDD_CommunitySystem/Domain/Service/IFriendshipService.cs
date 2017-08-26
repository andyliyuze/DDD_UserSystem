using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Service
{
 public   interface IFriendshipService:IDomainService
    {
        void BuildFriendship(Guid applicantUsertId, Guid receiverUserId);
    }
}
