using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain;

namespace DDD_UserSystem.DataMap
{
  public  class ContactMap
    {
      public static ContactDataModel MapToDataModel(Contact contact,Guid userId)
      {
          if(contact.ContactId==null    ||userId==Guid.Empty ){throw new Exception("contactId或UserId不能为空");}
          return new ContactDataModel() { ContactId = contact.ContactId, Phone = contact.Phone, QQ = contact.QQ, UserId = userId };
      }

    }
}
