﻿using DDD_CommunitySystem.Domain.Model;
using System;

namespace DDD_CommunitySystem.Domain.Repository
{
    public  interface IFriendsApplyRepository
    {
        FriendsApply Get(Guid applyId);
        void Add(FriendsApply apply);
        void Update(FriendsApply apply);
    }
}
