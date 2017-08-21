using DDD_UserSystem;
using DDD_UserSystem.DataMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain
{
    public class StudentRepository : IStudentRepository
    {
        private UserContext _context;


        public StudentRepository(IDbContext context) { _context = context as UserContext; }
        public void Add(Student student)
        {
            if (student.UserId == null) { throw new Exception("Id不能为空"); }
            foreach (var contact in student.Contacts) 
            {
               var contactDataModel= ContactMap.MapToDataModel(contact,student.UserId);
               _context.Contacts.Add(contactDataModel);
            }
            _context.Student.Add(student);
        }

        public Student Get(Guid userId)
        {
            Student stu  =  _context.Student.Find(userId);
            return stu;
        }


    }
}
