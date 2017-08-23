using DDD_CommunitySystem.DataModel;

namespace DDD_CommunitySystem.ApplicationService
{
    public  interface IFriendsApplyApplicationService
    {
        bool CreateFriendsApply(FriendsApplyDataModel apply);
    }
}
