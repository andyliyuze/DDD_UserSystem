using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Entity
{

    public class FriendsApply
    {


        public FriendsApply(Guid applicanUsertId,Guid receiverUserId) {

            FriendsApplyId = Guid.NewGuid();
            ApplicanUsertId = applicanUsertId;
            ReceiverUserId = receiverUserId;
            ApplyTime = DateTime.Now;
        
        }

        public Guid FriendsApplyId { get;private set; }
        
        public Guid ApplicanUsertId { get; private set; }
         
        public Guid ReceiverUserId { get; private set; }
        //申请时间
        public DateTime ApplyTime { get; private set; }

        //回复时间
        public Nullable<DateTime> ReplyTime { get; private set; }
        //申请结果     
        public string Result { get; private set; }
        
        public string HasReadResult { get; private set; }

    }
}
