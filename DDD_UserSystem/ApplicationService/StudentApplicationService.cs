using DDD_UserSystem;
using System;
using EntityFramework.Extensions;
using System.Linq;
using DDD_UserSystem.ApplicationService;

namespace UserDomain
{

    //应用程序层可以构造聚合，其客户端层不能传一个领域聚合到应用程序层
    public  class StudentApplicationService: IStudentApplicationService
    {

        private IStudentRepository _studentRepository;
        private IDbContext _context;
        public StudentApplicationService(IDbContext context, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _context = context;

        }

        public bool ChangePassword(Guid userId, string oldPwd, string newPwd)
        {
            Student student = _studentRepository.Get(userId);

            student.ChangePassword(oldPwd, newPwd);
            //EF有自动追踪功能
             //  _context.RegisterDirty<Student>(student);
            _context.Commit();
            return true;
        }


        public bool AddStudent(Student student)
        {
            _studentRepository.Add(student);
            int i=  _context.Commit();
            return i > 0;
        }


        public bool AddContact(Guid userId, int qq, int phone)
        {
            try
            {
                var contact = new Contact(qq, phone);
                Student student = _studentRepository.Get(userId);       
                var flag= student.AddContact(contact);
                if (flag)
                {
                    _studentRepository.Update(student);
                    _context.Commit();
                    return true;
                }
                return false;
            }
            catch { return false; throw; }
        }



        public bool RemoveSingleConatct(Guid contactId, Guid userId)
        {

            try
            {
             
                Student student = _studentRepository.Get(userId);
                var contact = student.Contacts.Where(a => a.ContactId == contactId).FirstOrDefault();
                if (contact!=null)
                {
                    student.Contacts.Remove(contact);
                    _studentRepository.Update(student);
                    _context.Commit();
                    return true;
                }
                return false;
            }
            catch {  throw; }

        }

    }
}
