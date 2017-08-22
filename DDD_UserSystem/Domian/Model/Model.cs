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
            Contacts = new List<Contact>();
        }
        public string Grade { get; private set; }
        public string IQ { get; private set; }
      
        public LoginInfo LoginInfo { get; private set; }
       
        public Address Address { get; private set; }
      
        public List<Contact> Contacts { get;   set; }





        public bool ChangePassword( string oldPassword, string newPassword)
        {

            if (oldPassword ==null || newPassword == null) { throw  new NullReferenceException("密码不能为空");  }
            if (oldPassword != LoginInfo.Password ) { return false; }
            var loginInfo = new LoginInfo() { LoginName = this.LoginInfo.LoginName, Password = newPassword };
            this.LoginInfo = loginInfo;
            return true;
        }

     
     
       
        public bool AddLoginInfo(string LoginName, string Pwd)
        {
            if (LoginName == null || Pwd == null) { throw new Exception("登录名或密码不能为空"); }
            var loginInfo =new LoginInfo() { LoginName = this.LoginInfo.LoginName, Password = Pwd };
            this.LoginInfo = loginInfo;
            return true;
        }



        public bool AddContact(Contact contact)
        {
            if (IsExistedBy(contact)) { return false; }
            Contacts.Add(contact);
            return true;
        }

        public bool IsExistedBy(Contact contact)
        {
            if (Contacts.Count == 0) { return false; }
            foreach (var model in Contacts)
            {

                if (model.Equals(contact)) return true;
            }
            return false;
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


        [Column("LoginName")]
        public string LoginName { get; set; }
        [Column("Password")]
        public string Password { get; set; }

    }
   
    public class Address
    {
         [Column("Contry")]
        public String Contry { get; set; }
          [Column("Detail")]
        public String Detail { get; set; }
    }
   //领域模型
    public class Contact
    {
        private Contact() { }
      

        public Contact(int qq, int phone)
        {
            if (qq == 0 && phone == 0) { throw new Exception("qq或电话不能全不为空"); }
            ContactId = Guid.NewGuid();
            QQ = qq;
            Phone = phone;
        }

        public Guid ContactId { get; set; }
        public int QQ { get;private set; }
        public int Phone { get;private set; }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null) return false;
            Contact other = obj as Contact;
            if ((object)other == null)  return false;
            return this.Phone.Equals(other.Phone) &&
                this.QQ.Equals(other.QQ) ;
        }


        public override int GetHashCode()
        {
            return this.QQ.GetHashCode() ^
                this.Phone.GetHashCode() ;
        }
    }

  
}
