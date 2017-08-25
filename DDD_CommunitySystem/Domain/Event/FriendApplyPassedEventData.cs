using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using DDD_CommunitySystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Event
{
 public   class  FriendsApplyPassedEventData:EntityEventData<FriendsApply>
    {
        public Guid receiverUserId;
        public Guid applicanUsertId;

        public FriendsApplyPassedEventData(FriendsApply entity) : base(entity)
        {
            receiverUserId = entity.ReceiverUserId;
            applicanUsertId = entity.ApplicanUsertId;
        }

         
    }
}
