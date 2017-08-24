using DDD_CommunitySystem.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass()]
    public class FriendsApply_Test
    {

        [TestMethod()]
        public void PassApply_Test_()
        {
            FriendsApply apply = new FriendsApply(Guid.NewGuid(), Guid.NewGuid());
            apply.PassApply();
        }
    }
   
}
