using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_UserSystem.Data.EF.DataModel
{
    public class StudentDataModel
    {
        public Guid ID { get; set; }
        public string RealName { get; set; }
        public string Age { get; set; }

        public string Grade { get; set; }
        public string IQ { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Contry { get; set; }

        public string Detail { get; set; }

        public List<ContactDataModel> Contacts { get; set; }
    }
}
