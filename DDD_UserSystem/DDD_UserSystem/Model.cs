using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain
{

    public class User
    {
        //lihai
        [Key]
        public  Guid UserId { get; set; }
          public  string RealName { get; set; }
          public string Age { get; set; }
         
    }
    

    public class Student : User
    {


        public Student()
        {

            Address = new Address();
            LoginInfo = new LoginInfo();
        }
        public string Grade { get; private set; }
        public string IQ { get; private set; }
      
        public LoginInfo LoginInfo { get; private set; }
       
        public Address Address { get; private set; }
        public List<Contact> Contacts { get; private set; }





        public bool ChangePassword( string oldPassword, string newPassword)
        {

            if (oldPassword ==null || newPassword == null) { throw  new NullReferenceException("密码不能为空");  }
            if (oldPassword != LoginInfo.Password ) { return false; }
            var loginInfo = new LoginInfo() { LoginName = this.LoginInfo.LoginName, Password = newPassword };
            this.LoginInfo = LoginInfo;
            return true;
        }

     
     
       
        public bool AddLoginInfo(string LoginName, string Pwd)
        {
            if (LoginName == null || Pwd == null) { throw new Exception("登录名或密码不能为空"); }
            var loginInfo =new LoginInfo() { LoginName = this.LoginInfo.LoginName, Password = Pwd };
            this.LoginInfo = LoginInfo;
            return true;
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
    
    [ComplexType]
    public class LoginInfo {
      


        public string LoginName { get; set; }
        public string Password { get; set; }

    }
    [ComplexType]
    public class Address
    {
        public String Contry { get; set; }
        public String Detail { get; set; }
    }
    [ComplexType]
    public class Contact
    {
       
        public int QQ { get; set; }
        public int Phone { get; set; }
    }
}
