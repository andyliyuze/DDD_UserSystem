using DDD_CommunitySystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.ApplicationService
{
  public  interface IFriendsApplyApplicationService
    {
        bool CreateFriendsApply(FriendsApplyDataModel apply);
    }
}
