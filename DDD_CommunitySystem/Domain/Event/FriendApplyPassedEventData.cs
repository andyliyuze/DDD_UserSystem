using Abp.Events.Bus;
using DDD_CommunitySystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Event
{
 public   class FriendApplyPassedEventData : EventData
    {
        private Guid _receiverUserId;
        private Guid _applicanUsertId;
        public FriendApplyPassedEventData(Guid receiverUserId,Guid applicanUsertId)
        {
            _receiverUserId = receiverUserId;
            _applicanUsertId = applicanUsertId;
        }
    }
}
