using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_UserSystem
{
    //表示仓储的接口
  public  interface IDbContext
    {
        int SaveChange();
    }
}
