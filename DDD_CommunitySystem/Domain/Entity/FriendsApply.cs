using Abp.Domain.Entities;
using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using DDD_CommunitySystem.Domain.Event;
using DDD_CommunitySystem.Domain.Event.Handler;
using System;

namespace DDD_CommunitySystem.Domain.Entity
{

    public class FriendsApply: Entity<Guid>
    {
        public FriendsApply(Guid applicanUsertId, Guid receiverUserId)
        {
            Id = Guid.NewGuid();
            ApplicanUsertId = applicanUsertId;
            ReceiverUserId = receiverUserId;
            ApplyTime = DateTime.Now;
           EventBus = NullEventBus.Instance;
       //     EventBus.Register<FriendApplyPassedEventData, FriendApplyPassedEventHandler>();
        }
        public IEventBus EventBus { get; set; }

  

        public Guid ApplicanUsertId { get; private set; }

        public Guid ReceiverUserId { get; private set; }
        //申请时间
        public DateTime ApplyTime { get; private set; }

        //回复时间
        public Nullable<DateTime> ReplyTime { get; private set; }
        //申请结果     
        public string Result { get; private set; }

        public string HasReadResult { get; private set; }



        public void PassApply()
        {
            this.ReplyTime = DateTime.Now;
            this.Result = "通过";
            //引发事件
            EventBus.Trigger(new FriendsApplyPassedEventData(this));
        }

 
        
    }
}
