using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
namespace DDD_CommunitySystem.Domain.Event.Handler
{
    public class FriendApplyPassedEventHandler : IEventHandler<FriendsApplyPassedEventData>    , ITransientDependency, IHandleMessages<FriendsApplyPassedEventData>
    {

        //   private FriendshipService _friendshipService;
        static ILog log = LogManager.GetLogger<FriendsApplyPassedEventData>();
        public FriendApplyPassedEventHandler()
        {
           
        }

        public Task Handle(FriendsApplyPassedEventData message, IMessageHandlerContext context)
        {
            log.Info($"Received OrderPlaced, OrderId = {message.receiverUserId} - Charging credit card...");
            return Task.CompletedTask;
        }

        public void HandleEvent(FriendsApplyPassedEventData eventData)
        {
            string a = "";
         //   _friendshipService.BuildFriendship(eventData.applicanUsertId, eventData.applicanUsertId);
        }

        

        
    }
}
