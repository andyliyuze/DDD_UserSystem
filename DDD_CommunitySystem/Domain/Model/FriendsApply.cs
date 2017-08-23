using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Model
{

    public class FriendsApply
    {

      
        public Guid FriendsApplyId { get; set; }
        
        public Guid ApplicantId { get; set; }
         
        public Guid ReceiverUserId { get; set; }
        //申请时间
        public DateTime ApplyTime { get; set; }

        //回复时间
        public DateTime ReplyTime { get; set; }
        //申请结果     
        public string Result { get; set; }
        
        public string HasReadResult { get; set; }

    }
}
