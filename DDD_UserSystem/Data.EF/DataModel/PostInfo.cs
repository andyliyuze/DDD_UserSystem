using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_UserSystem.Data.EF.DataModel
{
 public   class PostInfo
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }
    }
}
