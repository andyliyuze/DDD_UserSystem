using DDD_UserSystem.Data.EF.DataModel;
using System;
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
        public static Contact  MapToDomainModel(ContactDataModel contact, Guid userId)
        {
            if (contact.ContactId == null || userId == Guid.Empty) { throw new Exception("contactId或UserId不能为空"); }
            var domainModel= new Contact( contact.Phone, contact.QQ) ;
            domainModel.ContactId = contact.ContactId;
            return domainModel;
        }
    }
}
