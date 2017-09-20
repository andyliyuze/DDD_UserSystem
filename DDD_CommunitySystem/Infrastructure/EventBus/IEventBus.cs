using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_CommunitySystem.Infrastructure.EventBus
{
   public interface IEventBus
    {
        void Publish(object message);

    }
}
