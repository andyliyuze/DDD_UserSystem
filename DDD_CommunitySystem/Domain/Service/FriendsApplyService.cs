using DDD_CommunitySystem.Domain.Entity;
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Rule.Interfac;
using DDD_CommunitySystem.Domain.ValueObject;
using System;
using System.Linq;

namespace DDD_CommunitySystem.Domain.Service
{
    public class FriendsApplyService
    {

        private IFriendsApplyRepository _friendsApplyRepository;
        public FriendsApplyService(IFriendsApplyRepository friendsApplyRepository)
        {
            _friendsApplyRepository = friendsApplyRepository;
        }
        public CreateFriendApplyRepond CreateSingleFriendsApply(Guid applicantUserId, Guid receiverUserId)
        {
            //获取实现该接口的所有类
            var types = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICreateFriendsApplyBeforeRule)) && t.IsClass == true)
              ).ToArray();
            foreach (var v in types)
            {
                var respond = (Activator.CreateInstance(v) as ICreateFriendsApplyBeforeRule).verify(applicantUserId, receiverUserId);
                if (respond.Result == CreateFriendApplyResult.faild) { return respond; }
            }

            var friendsApply = new FriendsApply(applicantUserId, receiverUserId);
            _friendsApplyRepository.Add(friendsApply);
            return new CreateFriendApplyRepond()
            {
                Result = CreateFriendApplyResult.succeed
            };
        }


        public bool IsInBacklist(Guid applicantUserId, Guid receiverUserId) { return false; }

        public bool IsFriend(Guid applicantUserId, Guid receiverUserId) { return false; }
    }
}
