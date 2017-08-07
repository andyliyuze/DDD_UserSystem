using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain
{

    public class User
    {


          public  Guid UserId { get; set; }
          public  string RealName { get; set; }
          public string Age { get; set; }
         
    }

    public class Student : User
    {
        public string Grade { get; set; }
        public string IQ { get; set; }
        private LoginInfo LoginInfo { get; set; }
        private Address Address { get; set; }
        private List<Contact> Contacts { get; set; }





        public void ChangePassword( string oldPassword, string newPassword)
        {
            if (oldPassword != LoginInfo.Password || oldPassword == null) { return ; }
            else { LoginInfo.Password = newPassword; }
        }

        public bool Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

     
        public Address GetAddress(Guid Id)
        {
            throw new NotImplementedException();
        }
        public bool AddLoginInfo(Guid userId, string LoginName, string Pwd)
        {
            throw new NotImplementedException();
        }

    }









    public class Teacher : User
    {
        public string TeachingYears { get; set; }
        public string DeptId { set; get; }
        public LoginInfo LoginInfo { get; set; }
        public Address Address { get; set; }
        public List<Contact> Contacts { get; set; }
    }
    public class LoginInfo {
        public Guid UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

    }

    public class Address
    {

        public Guid UserId { get; set; }
        public String Contry { get; set; }
        public String Detail { get; set; }
    }

    public class Contact
    {
        public Guid UserId { get; set; }
        public int QQ { get; set; }
        public int Phone { get; set; }
    }
}
