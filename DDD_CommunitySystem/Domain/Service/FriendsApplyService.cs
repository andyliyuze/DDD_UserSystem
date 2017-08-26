using Abp.Domain.Services;
using DDD_CommunitySystem.Domain.Entity;
using DDD_CommunitySystem.Domain.Repository;
using DDD_CommunitySystem.Domain.Rule.Interfac;
using DDD_CommunitySystem.Domain.ValueObject;
using DDD_CommunitySystem.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD_CommunitySystem.Domain.Service
{
    public class FriendsApplyService: IFriendsApplyService
    {

        private IFriendsApplyRepository _friendsApplyRepository;
        private static Dictionary<string, object> cacheManager = new Dictionary<string, object>();
        private static Type[] types=null;
        private IFriendshipRepository _friendshipRepository;
        private IBlacklistRelationRepository _blacklistRelationRepository;
        public FriendsApplyService(IFriendsApplyRepository friendsApplyRepository, IFriendshipRepository friendshipRepository, IBlacklistRelationRepository blacklistRelationRepository)
        {
            _friendsApplyRepository = friendsApplyRepository;
            _friendshipRepository = friendshipRepository;
            _blacklistRelationRepository = blacklistRelationRepository;

        }
        public CreateFriendApplyRepond CreateSingleFriendsApply(Guid applicantUserId, Guid receiverUserId)
        {
            if (types == null)
            {
                //获取实现该接口的所有类
                types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICreateFriendsApplyBeforeRule)) && t.IsClass == true)
                ).ToArray();
            }
            foreach (var v in types)
            {
                ICreateFriendsApplyBeforeRule instance;
                if (cacheManager.ContainsKey(v.ToString()))
                {
                    instance = (ICreateFriendsApplyBeforeRule)cacheManager.Where(a => a.Key == v.ToString()).FirstOrDefault().Value;
                }
                else
                {
                    instance = Activator.CreateInstance(v) as ICreateFriendsApplyBeforeRule;
                    cacheManager.Add(v.ToString(), instance);
                }
                var respond = instance.verify(applicantUserId, receiverUserId,this);
                if (respond.Result == CreateFriendApplyResult.faild) { return respond; }
            }
            var friendsApply = new FriendsApply(applicantUserId, receiverUserId);
            _friendsApplyRepository.Add(friendsApply);
            return new CreateFriendApplyRepond()
            {
                Result = CreateFriendApplyResult.succeed
            };
        }




        public void PassFriendsApply(Guid applyId)
        {

           var apply= _friendsApplyRepository.Get(applyId);
            
        }



        public bool IsInBacklist(Guid applicantUserId, Guid receiverUserId)
        {
            if (_blacklistRelationRepository.Get(applicantUserId, receiverUserId) != null)
            {
                return true;
            }
            return false;
        }
        public bool IsBeFriend(Guid applicantUserId, Guid receiverUserId)
        {
            if (_friendshipRepository.Get(applicantUserId, receiverUserId) != null)
            {
                return true;           
            }
            return false;
        }
    }
}
