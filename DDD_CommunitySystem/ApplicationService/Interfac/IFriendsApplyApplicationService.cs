using Abp.Application.Services;
using DDD_CommunitySystem.DataModel;

namespace DDD_CommunitySystem.ApplicationService.Interfac
{
    public  interface IFriendsApplyApplicationService: IApplicationService
    {
        bool CreateFriendsApply(FriendsApplyDataModel apply);
    }
}
