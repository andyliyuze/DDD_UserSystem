using DDD_CommunitySystem.DataModel;

namespace DDD_CommunitySystem.ApplicationService.Interfac
{
    public  interface IFriendsApplyApplicationService
    {
        bool CreateFriendsApply(FriendsApplyDataModel apply);
    }
}
