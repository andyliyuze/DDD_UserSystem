using DDD_CommunitySystem.Domain.Entity;
using DDD_CommunitySystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Service
{
  public  class FriendshipService
    {

       
        private IFriendshipRepository _friendshipRepository;
        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;

        }
        public void BuildFriendship(Guid applicantUsertId, Guid receiverUserId)
        {
            var friendshipForApplicant = new Friendship(applicantUsertId, receiverUserId, true);
            var friendshipForReceiver = new Friendship(receiverUserId, applicantUsertId,  false);
            _friendshipRepository.Add(friendshipForApplicant);
            _friendshipRepository.Add(friendshipForReceiver);
        }
        


        
    }
}
