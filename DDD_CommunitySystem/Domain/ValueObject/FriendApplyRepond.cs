using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.ValueObject
{
  public  class CreateFriendApplyRepond
   {

          public CreateFriendApplyResult Result { get; set; }
          public FaildReason FaildReason { get; set; }
    }


    public enum CreateFriendApplyResult
    {
        succeed ,
        faild 
    }
    public   enum FaildReason
    {
        BeInBacklist,
        BeFriend
    }
}
