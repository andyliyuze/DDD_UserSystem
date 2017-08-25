﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Domain.Entity
{
   public  class Friendship
    {

        public Friendship(Guid userId, Guid friendsId,bool isApplicant)
        {
            FriendShipId = Guid.NewGuid();
            UserId = userId;
            FriendsId = friendsId;
            IsApplicant = isApplicant;
            BefriendTime = DateTime.Now;
        }

        public Guid FriendShipId { get;   set;   }

        public Guid UserId { get; set; }
        public Guid FriendsId { get; set; }

        public DateTime BefriendTime { get; set; }

        public bool IsApplicant { get; set; }
    }
}
