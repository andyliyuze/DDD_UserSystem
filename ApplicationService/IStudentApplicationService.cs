using DDD_UserSystem.Data.EF.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain;

namespace DDD_UserSystem.ApplicationService
{
  public  interface IStudentApplicationService
    {
        bool ChangePassword(Guid userId, string oldPwd, string newPwd);
        bool AddStudent(StudentDataModel student);
        bool AddContact(Guid userId, int qq, int phone);
        bool RemoveSingleConatct(Guid contactId, Guid userId);
        bool Remove(Guid UserId);
    }
}
